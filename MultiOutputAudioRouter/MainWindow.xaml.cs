using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using NAudio.CoreAudioApi;
using NAudio.Wave;

namespace MultiOutputAudioRouter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AudioRouter? audioRouter;
        private List<DeviceCheckBox> deviceCheckBoxes = new List<DeviceCheckBox>();
        private ConfigurationManager.Configuration configuration;

        public MainWindow()
        {
            InitializeComponent();
            configuration = ConfigurationManager.LoadConfiguration();
            LoadAudioDevices();
        }

        private void LoadAudioDevices()
        {
            DeviceListPanel.Children.Clear();
            deviceCheckBoxes.Clear();

            try
            {
                var enumerator = new MMDeviceEnumerator();
                var devices = enumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active);

                if (devices.Count == 0)
                {
                    var noDevicesText = new TextBlock
                    {
                        Text = "No audio output devices found.",
                        Margin = new Thickness(10),
                        FontStyle = FontStyles.Italic
                    };
                    DeviceListPanel.Children.Add(noDevicesText);
                    UpdateStatus("No audio devices found");
                    return;
                }

                foreach (var device in devices)
                {
                    var checkBox = new CheckBox
                    {
                        Content = device.FriendlyName,
                        Margin = new Thickness(5),
                        Tag = device.ID
                    };

                    // Restore previous selection from configuration
                    if (configuration.SelectedDeviceIds.Contains(device.ID))
                    {
                        checkBox.IsChecked = true;
                    }

                    deviceCheckBoxes.Add(new DeviceCheckBox
                    {
                        CheckBox = checkBox,
                        DeviceId = device.ID,
                        DeviceName = device.FriendlyName
                    });

                    DeviceListPanel.Children.Add(checkBox);
                }

                UpdateStatus($"Found {devices.Count} audio output device(s)");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading audio devices: {ex.Message}", "Error", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
                UpdateStatus("Error loading devices");
            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedDevices = deviceCheckBoxes
                .Where(d => d.CheckBox.IsChecked == true)
                .Select(d => d.DeviceId)
                .ToList();

            if (selectedDevices.Count < 2)
            {
                MessageBox.Show("Please select at least 2 audio output devices to route audio.", 
                    "Selection Required", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            try
            {
                audioRouter = new AudioRouter(selectedDevices);
                audioRouter.Start();

                StartButton.IsEnabled = false;
                StopButton.IsEnabled = true;

                // Disable device selection while routing
                foreach (var deviceCheckBox in deviceCheckBoxes)
                {
                    deviceCheckBox.CheckBox.IsEnabled = false;
                }

                UpdateStatus($"Routing audio to {selectedDevices.Count} device(s)");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error starting audio router: {ex.Message}", "Error", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
                UpdateStatus("Error starting router");
            }
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                audioRouter?.Stop();
                audioRouter?.Dispose();
                audioRouter = null;

                StartButton.IsEnabled = true;
                StopButton.IsEnabled = false;

                // Re-enable device selection
                foreach (var deviceCheckBox in deviceCheckBoxes)
                {
                    deviceCheckBox.CheckBox.IsEnabled = true;
                }

                // Save current device selection
                SaveConfiguration();

                UpdateStatus("Routing stopped");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error stopping audio router: {ex.Message}", "Error", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
                UpdateStatus("Error stopping router");
            }
        }

        private void SaveConfiguration()
        {
            try
            {
                configuration.SelectedDeviceIds = deviceCheckBoxes
                    .Where(d => d.CheckBox.IsChecked == true)
                    .Select(d => d.DeviceId)
                    .ToList();

                ConfigurationManager.SaveConfiguration(configuration);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error saving configuration: {ex.Message}");
            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            LoadAudioDevices();
        }

        private void UpdateStatus(string message)
        {
            StatusText.Text = $"{DateTime.Now:HH:mm:ss} - {message}";
        }

        protected override void OnClosed(EventArgs e)
        {
            audioRouter?.Stop();
            audioRouter?.Dispose();
            SaveConfiguration();
            base.OnClosed(e);
        }

        private class DeviceCheckBox
        {
            public CheckBox CheckBox { get; set; } = null!;
            public string DeviceId { get; set; } = string.Empty;
            public string DeviceName { get; set; } = string.Empty;
        }
    }
}
