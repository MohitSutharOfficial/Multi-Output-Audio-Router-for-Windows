using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NAudio.CoreAudioApi;
using NAudio.Wave;

namespace MultiOutputAudioRouter
{
    /// <summary>
    /// Core audio routing engine that captures audio from the default device
    /// and duplicates it to multiple selected output devices simultaneously.
    /// </summary>
    public class AudioRouter : IDisposable
    {
        private readonly List<string> targetDeviceIds;
        private WasapiLoopbackCapture? capture;
        private readonly List<WasapiOut> outputDevices = new List<WasapiOut>();
        private readonly List<BufferedWaveProvider> bufferProviders = new List<BufferedWaveProvider>();
        private bool isRunning;
        private readonly object lockObject = new object();

        public AudioRouter(List<string> deviceIds)
        {
            if (deviceIds == null || deviceIds.Count < 2)
            {
                throw new ArgumentException("At least 2 devices must be specified for routing.");
            }

            targetDeviceIds = deviceIds;
        }

        public void Start()
        {
            lock (lockObject)
            {
                if (isRunning)
                {
                    return;
                }

                try
                {
                    // Initialize the loopback capture from the default audio device
                    capture = new WasapiLoopbackCapture();

                    // Initialize output devices and buffers
                    var enumerator = new MMDeviceEnumerator();
                    foreach (var deviceId in targetDeviceIds)
                    {
                        try
                        {
                            var device = enumerator.GetDevice(deviceId);
                            var wasapiOut = new WasapiOut(device, AudioClientShareMode.Shared, false, 100);
                            
                            // Create a buffer provider for this device
                            var bufferProvider = new BufferedWaveProvider(capture.WaveFormat)
                            {
                                BufferDuration = TimeSpan.FromSeconds(2),
                                DiscardOnBufferOverflow = true
                            };

                            wasapiOut.Init(bufferProvider);
                            wasapiOut.Play();

                            outputDevices.Add(wasapiOut);
                            bufferProviders.Add(bufferProvider);
                        }
                        catch (Exception ex)
                        {
                            // Log error but continue with other devices
                            System.Diagnostics.Debug.WriteLine($"Error initializing device {deviceId}: {ex.Message}");
                        }
                    }

                    if (outputDevices.Count == 0)
                    {
                        throw new InvalidOperationException("No output devices could be initialized.");
                    }

                    // Subscribe to data available event
                    capture.DataAvailable += OnDataAvailable;

                    // Start capturing
                    capture.StartRecording();
                    isRunning = true;
                }
                catch (Exception)
                {
                    // Clean up on failure
                    Stop();
                    throw;
                }
            }
        }

        private void OnDataAvailable(object? sender, WaveInEventArgs e)
        {
            if (!isRunning || e.BytesRecorded == 0)
            {
                return;
            }

            // Duplicate the audio data to all buffer providers
            lock (lockObject)
            {
                foreach (var bufferProvider in bufferProviders)
                {
                    try
                    {
                        bufferProvider.AddSamples(e.Buffer, 0, e.BytesRecorded);
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"Error adding samples to buffer: {ex.Message}");
                    }
                }
            }
        }

        public void Stop()
        {
            lock (lockObject)
            {
                isRunning = false;

                if (capture != null)
                {
                    capture.DataAvailable -= OnDataAvailable;
                    capture.StopRecording();
                    capture.Dispose();
                    capture = null;
                }

                foreach (var output in outputDevices)
                {
                    try
                    {
                        output.Stop();
                        output.Dispose();
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"Error stopping output device: {ex.Message}");
                    }
                }

                outputDevices.Clear();
                bufferProviders.Clear();
            }
        }

        public void Dispose()
        {
            Stop();
        }
    }
}
