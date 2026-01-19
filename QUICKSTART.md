# Quick Start Guide

## Getting Started in 3 Simple Steps

### Step 1: Download & Install

1. Download the latest release from the [Releases](https://github.com/MohitSutharOfficial/Multi-Output-Audio-Router-for-Windows/releases) page
2. Extract the ZIP file to a folder (e.g., `C:\Program Files\MultiOutputAudioRouter`)
3. Run `MultiOutputAudioRouter.exe`

**OR** if you have .NET 6.0 Runtime installed:
- Download the smaller framework-dependent version
- Requires [.NET 6.0 Runtime](https://dotnet.microsoft.com/download/dotnet/6.0)

### Step 2: Select Your Devices

1. When the application opens, you'll see a list of all available audio output devices
2. Check the boxes next to **at least 2 devices** you want to use
3. Examples:
   - ✅ Built-in Speakers
   - ✅ Bluetooth Headphones
   - ✅ USB Speakers

### Step 3: Start Routing

1. Click the **"Start Routing"** button
2. Open your media player (VLC, YouTube, Spotify, etc.)
3. Play audio - it will now play on ALL selected devices simultaneously!
4. Click **"Stop Routing"** when done

## Common Use Cases

### Watching Movies with Friends
**Scenario**: You want to watch a movie where multiple people use different audio devices.

1. Connect all audio devices (headphones, earphones, etc.)
2. Open Multi-Output Audio Router
3. Select all devices you want to use
4. Click "Start Routing"
5. Open VLC and play your movie
6. Everyone can hear the audio on their own device!

### Multi-Room Audio
**Scenario**: Play music in different rooms simultaneously.

1. Set up speakers in different rooms (Bluetooth or wired)
2. Select all speaker devices in the app
3. Click "Start Routing"
4. Play music from any app
5. Enjoy synchronized audio throughout your home!

### Recording & Monitoring
**Scenario**: Record audio on one device while monitoring on another.

1. Select your recording device (e.g., "Line In")
2. Select your monitoring device (e.g., "Headphones")
3. Start routing
4. You can now record while hearing playback

## Tips & Tricks

### Saving Time
- The app **remembers your device selections** between sessions
- No need to reselect devices each time you restart the app

### Best Performance
- Use **wired devices** when possible for lowest latency
- **Bluetooth devices** may have a slight delay (100-200ms)
- Close unnecessary audio applications to free up resources

### Device Management
- Click **"Refresh Devices"** if you connect/disconnect devices
- The app only shows **active** devices
- Disabled devices won't appear in the list

## Troubleshooting Quick Fixes

### Problem: No devices showing
**Solution**: 
1. Check Windows Sound Settings
2. Ensure devices are enabled and working
3. Click "Refresh Devices" button

### Problem: No audio playing
**Solution**:
1. Verify devices are selected (checkboxes checked)
2. Ensure "Start Routing" was clicked
3. Check Windows volume levels for each device
4. Try stopping and starting routing again

### Problem: Audio stuttering
**Solution**:
1. Close other audio applications
2. Reduce the number of selected devices
3. Update audio drivers
4. Try wired devices instead of Bluetooth

## System Requirements

- **OS**: Windows 10 or later (64-bit)
- **RAM**: 4 GB minimum, 8 GB recommended
- **Audio**: At least 2 audio output devices
- **.NET**: .NET 6.0 Runtime (for framework-dependent version)

## Keyboard Shortcuts

Currently, the application doesn't have keyboard shortcuts, but this feature may be added in future versions.

## Need More Help?

- 📖 Read the full [README](README.md)
- 🔧 Check the [Troubleshooting Guide](TROUBLESHOOTING.md)
- 🏗️ View [Build Instructions](BUILD.md)
- 🐛 [Report Issues](../../issues)
- 💡 [Request Features](../../issues/new)

## Advanced Usage

### Command Line (Future Feature)
Future versions may support command-line operation:
```bash
MultiOutputAudioRouter.exe --devices "Device1,Device2" --autostart
```

### Configuration File Location
Your preferences are saved in:
```
%APPDATA%\MultiOutputAudioRouter\config.json
```

You can delete this file to reset all settings.

---

**That's it!** You're now ready to route audio to multiple devices simultaneously. Enjoy your multi-output audio experience! 🎵🎧🔊
