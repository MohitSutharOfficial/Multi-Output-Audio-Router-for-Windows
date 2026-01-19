# Multi-Output Audio Router for Windows

A Windows desktop application that captures system audio and duplicates it to multiple audio output devices simultaneously. Perfect for watching movies on VLC or other media players while having audio play on all your connected devices (speakers, earphones, Bluetooth headphones) without needing to share physical devices.

## Features

- 🎵 **Multi-Device Audio Routing**: Route audio to multiple output devices simultaneously
- 🔊 **System-Wide Audio Capture**: Captures all system audio using WASAPI loopback
- 🎬 **Works with Any Application**: Compatible with VLC, media players, games, and all other audio sources
- 🖥️ **User-Friendly Interface**: Simple WPF interface for device selection and control
- ⚡ **Real-Time Processing**: Low-latency audio routing for seamless playback
- 🔄 **Device Management**: Easy refresh and selection of available audio devices

## Requirements

- Windows 10 or later (64-bit)
- .NET 6.0 Runtime or later
- At least 2 audio output devices

## Installation

### Option 1: Download Pre-built Binary (Recommended)
1. Go to the [Releases](../../releases) page
2. Download the latest `MultiOutputAudioRouter.zip`
3. Extract the ZIP file to a folder of your choice
4. Run `MultiOutputAudioRouter.exe`

### Option 2: Build from Source

#### Prerequisites
- Visual Studio 2022 or later (with .NET desktop development workload)
- .NET 6.0 SDK or later

#### Build Steps
1. Clone the repository:
   ```bash
   git clone https://github.com/MohitSutharOfficial/Multi-Output-Audio-Router-for-Windows.git
   cd Multi-Output-Audio-Router-for-Windows
   ```

2. Open the solution in Visual Studio:
   ```bash
   MultiOutputAudioRouter.sln
   ```

3. Restore NuGet packages:
   - Visual Studio will automatically restore packages
   - Or manually: `dotnet restore`

4. Build the solution:
   - Press `Ctrl+Shift+B` in Visual Studio
   - Or use command line: `dotnet build --configuration Release`

5. Run the application:
   - Press `F5` in Visual Studio
   - Or navigate to `bin/Release/net6.0-windows/` and run `MultiOutputAudioRouter.exe`

## Usage

1. **Launch the Application**
   - Run `MultiOutputAudioRouter.exe`
   - The application will scan and display all available audio output devices

2. **Select Output Devices**
   - Check the boxes next to the audio devices you want to use
   - You must select at least 2 devices to start routing

3. **Start Routing**
   - Click the "Start Routing" button
   - Audio from all applications (VLC, Chrome, games, etc.) will now play on all selected devices

4. **Stop Routing**
   - Click the "Stop Routing" button when you want to return to normal audio output

5. **Refresh Devices**
   - If you connect or disconnect audio devices, click "Refresh Devices" to update the list

## How It Works

The application uses Windows Audio Session API (WASAPI) to:
1. **Capture**: Use loopback capture to record all system audio
2. **Duplicate**: Copy the audio stream to multiple buffers
3. **Route**: Play each buffer through a different audio output device

This creates a real-time audio duplication system that works with any application without requiring application-specific configuration.

## Use Cases

- **Shared Movie Watching**: Play movies on VLC while multiple people use different audio devices
- **Multi-Room Audio**: Route audio to speakers in different rooms simultaneously
- **Recording & Monitoring**: Record audio on one device while monitoring on another
- **Accessibility**: Use multiple audio devices for different purposes simultaneously
- **Gaming**: Share game audio with multiple viewers or recorders

## Technical Details

- **Framework**: .NET 6.0 WPF
- **Audio Library**: NAudio 2.2.1 with WASAPI support
- **Architecture**: Event-driven audio streaming with buffered wave providers
- **Audio Format**: Supports all WASAPI-compatible formats
- **Latency**: ~100ms buffer for smooth playback

## Troubleshooting

### No Audio Devices Found
- Ensure your audio devices are properly connected and recognized by Windows
- Check Windows Sound Settings to verify devices are enabled
- Try refreshing the device list in the application

### Audio Quality Issues
- Some devices may have different sample rates; Windows will automatically resample
- Reduce the number of simultaneous output devices if experiencing performance issues
- Close other audio applications if experiencing buffer issues

### Application Won't Start
- Ensure .NET 6.0 Runtime is installed
- Run as Administrator if you encounter permission issues
- Check Windows Event Viewer for error details

### Audio Delay/Sync Issues
- Some latency is expected due to buffering
- Bluetooth devices may have additional latency
- Try using wired devices for better synchronization

## Limitations

- Requires Windows 10 or later with WASAPI support
- Some audio devices may not support shared mode
- Bluetooth devices may have additional latency
- DRM-protected content may not be captured by some applications

## Privacy & Security

- This application only captures and routes audio; no data is stored or transmitted
- No internet connection required
- No telemetry or analytics
- Open source - inspect the code yourself!

## Contributing

Contributions are welcome! Please feel free to submit issues, feature requests, or pull requests.

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## License

This project is open source and available under the MIT License.

## Acknowledgments

- Built with [NAudio](https://github.com/naudio/NAudio) - Audio library for .NET
- Uses Windows Audio Session API (WASAPI)

## Support

If you find this project helpful, please consider:
- ⭐ Starring the repository
- 🐛 Reporting bugs and issues
- 💡 Suggesting new features
- 🤝 Contributing code improvements

## Author

**Mohit Suthar**
- GitHub: [@MohitSutharOfficial](https://github.com/MohitSutharOfficial)

---

**Note**: This application is designed for personal use. Please respect copyright laws and terms of service when using with media content.
