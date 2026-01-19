# Troubleshooting Guide

This guide helps you resolve common issues with the Multi-Output Audio Router application.

## Installation Issues

### Issue: "Application won't start"

**Symptoms**: Double-clicking the .exe does nothing or shows an error.

**Solutions**:
1. **Install .NET 6.0 Runtime**
   - Download from: https://dotnet.microsoft.com/download/dotnet/6.0
   - Install the "Desktop Runtime" (not SDK unless you're developing)
   - Restart your computer after installation

2. **Run as Administrator**
   - Right-click `MultiOutputAudioRouter.exe`
   - Select "Run as administrator"
   - If this fixes it, you may need to adjust file permissions

3. **Check Windows Event Viewer**
   - Open Event Viewer (search in Start menu)
   - Navigate to Windows Logs > Application
   - Look for errors related to MultiOutputAudioRouter

4. **Antivirus/Firewall**
   - Some antivirus software may block the application
   - Add an exception for MultiOutputAudioRouter.exe
   - Temporarily disable antivirus to test

### Issue: "Missing DLL" error

**Solution**: Extract the entire ZIP file, not just the .exe file. All DLL files must be in the same folder.

## Device Detection Issues

### Issue: "No audio output devices found"

**Solutions**:
1. **Check Windows Sound Settings**
   ```
   Settings > System > Sound > Output
   ```
   - Verify your devices appear in Windows
   - Ensure devices are not disabled
   - Set at least one device as default

2. **Enable Hidden Devices**
   - Open Device Manager
   - View > Show hidden devices
   - Expand "Sound, video and game controllers"
   - Enable any disabled audio devices

3. **Update Audio Drivers**
   - Open Device Manager
   - Right-click audio device
   - Select "Update driver"
   - Choose "Search automatically"
   - Restart computer after update

4. **Restart Windows Audio Service**
   ```
   1. Press Win + R
   2. Type "services.msc"
   3. Find "Windows Audio"
   4. Right-click > Restart
   ```

### Issue: "Specific device not showing in list"

**Solutions**:
1. **Check Device Status in Windows**
   - Open Sound Control Panel (Control Panel > Hardware and Sound > Sound)
   - Right-click in empty area > "Show Disabled Devices"
   - Right-click device > Enable

2. **Device State**
   - The app only shows **Active** devices
   - Ensure device is connected and powered on
   - For Bluetooth: Pair and connect the device first

3. **Click "Refresh Devices"**
   - Connect/disconnect your device
   - Click the "Refresh Devices" button in the app

## Audio Routing Issues

### Issue: "No audio on selected devices"

**Solutions**:
1. **Verify Device Selection**
   - Ensure checkboxes are checked for desired devices
   - At least 2 devices must be selected
   - Click "Start Routing" button

2. **Check Volume Levels**
   - Open Windows Volume Mixer (right-click speaker icon in taskbar)
   - Verify volume is not muted for each device
   - Check application volume levels

3. **Test Audio in Windows**
   - Go to Sound Settings
   - Select each device
   - Click "Test" button
   - If Windows test fails, the device itself has issues

4. **Restart Routing**
   - Click "Stop Routing"
   - Wait 2 seconds
   - Click "Start Routing" again

### Issue: "Audio only plays on some devices"

**Solutions**:
1. **Sample Rate Mismatch**
   - Different devices may use different sample rates
   - Windows usually handles this automatically
   - Try setting all devices to the same sample rate:
     ```
     1. Control Panel > Sound
     2. Select device > Properties > Advanced
     3. Set to same format (e.g., "24 bit, 48000 Hz")
     4. Repeat for all devices
     ```

2. **Exclusive Mode**
   - Disable exclusive mode on all devices:
     ```
     1. Control Panel > Sound
     2. Right-click device > Properties
     3. Advanced tab
     4. Uncheck "Allow applications to take exclusive control"
     ```

3. **Check Device Capabilities**
   - Some devices may not support shared mode
   - Try different devices to isolate the problem

### Issue: "Audio stuttering or crackling"

**Solutions**:
1. **Reduce Device Count**
   - Start with just 2 devices
   - Add more one at a time to find the limit

2. **Update Audio Drivers**
   - Outdated drivers can cause performance issues
   - Check manufacturer website for latest drivers

3. **Increase Buffer Size** (Future feature)
   - Currently uses fixed 100ms buffer
   - Future versions may allow adjustment

4. **System Performance**
   - Close unnecessary applications
   - Check CPU usage in Task Manager
   - Ensure adequate RAM available
   - Disable audio enhancements in Windows

5. **Bluetooth Issues**
   - Bluetooth has inherent latency
   - Try moving closer to Bluetooth adapter
   - Remove interference sources
   - Consider using wired devices

### Issue: "Audio delay/sync issues between devices"

**Explanation**: Some latency is expected, especially with Bluetooth devices.

**Solutions**:
1. **Use Wired Devices**
   - Wired devices have lowest latency
   - Bluetooth can have 100-300ms delay

2. **Consistent Device Types**
   - Mix of wired and Bluetooth will have sync issues
   - Use all wired or manage expectations

3. **Disable Audio Enhancements**
   ```
   1. Control Panel > Sound
   2. Select device > Properties
   3. Enhancements tab
   4. Check "Disable all enhancements"
   5. Repeat for all devices
   ```

## Application Behavior Issues

### Issue: "Application crashes on start"

**Solutions**:
1. **Check Event Viewer** (as described above)

2. **Delete Configuration**
   - Navigate to: `%APPDATA%\MultiOutputAudioRouter\`
   - Delete `config.json`
   - Restart application

3. **Reinstall**
   - Delete the application folder
   - Re-extract from ZIP
   - Run as administrator first time

### Issue: "Can't stop routing"

**Solutions**:
1. **Force Stop**
   - Close the application completely
   - Reopen it
   - Audio routing will automatically stop

2. **Restart Windows Audio Service** (as described above)

3. **Task Manager**
   - Open Task Manager (Ctrl+Shift+Esc)
   - Find MultiOutputAudioRouter
   - End task
   - Restart application

### Issue: "Settings not saving"

**Solutions**:
1. **Check Permissions**
   - Application needs write access to:
     `%APPDATA%\MultiOutputAudioRouter\`
   - Run as administrator if permission denied

2. **Antivirus Blocking**
   - Some antivirus may block file writes
   - Add exception for the AppData folder

## Performance Issues

### Issue: "High CPU usage"

**Solutions**:
1. **Expected Behavior**
   - Some CPU usage is normal for audio processing
   - 5-15% is typical depending on device count

2. **Reduce Device Count**
   - More devices = more CPU usage
   - Try using fewer devices

3. **Background Applications**
   - Close other audio applications
   - Disable audio enhancements

### Issue: "High memory usage"

**Solutions**:
1. **Expected Behavior**
   - Memory usage increases with buffer size
   - 50-200 MB is normal

2. **Memory Leak**
   - If memory keeps growing, report as bug
   - Restart application periodically as workaround

## Compatibility Issues

### Issue: "Doesn't work with specific application"

**Known Limitations**:
- **DRM-protected content**: Some streaming services use DRM that prevents audio capture
- **Exclusive mode apps**: Some professional audio software uses exclusive mode
- **ASIO applications**: Applications using ASIO drivers may bypass WASAPI

**Solutions**:
1. **Check Application Settings**
   - Disable exclusive audio mode in the application
   - Use WASAPI output if available

2. **Test with Different App**
   - Try VLC, Windows Media Player, or YouTube
   - If works with these, issue is with specific app

### Issue: "Windows version compatibility"

**Requirements**:
- Windows 10 or later required
- Windows 7/8 not supported (missing WASAPI features)

**Solution**: Upgrade to Windows 10 or later

## Getting More Help

If you've tried these solutions and still have issues:

### 1. Check Existing Issues
Visit: https://github.com/MohitSutharOfficial/Multi-Output-Audio-Router-for-Windows/issues

### 2. Create a New Issue
Include:
- Windows version (Win+R, type `winver`)
- Application version
- List of audio devices
- Steps to reproduce
- Screenshots of error messages
- Relevant Event Viewer logs

### 3. Provide System Information

Run this in Command Prompt:
```cmd
systeminfo > systeminfo.txt
```

Attach the output file to your issue report.

### 4. Audio Device Information

Export audio device list:
```powershell
Get-PnpDevice -Class AudioEndpoint | Format-List > audio_devices.txt
```

## Diagnostic Mode (Future Feature)

Future versions may include a diagnostic mode:
```bash
MultiOutputAudioRouter.exe --debug --log-level verbose
```

This would create detailed logs for troubleshooting.

## Common Misconceptions

### "It should work with any device"
- Some devices don't support shared audio mode
- Bluetooth limitations are device-specific
- Professional audio interfaces may not work

### "Zero latency is possible"
- Some latency is inherent in audio buffering
- 100ms buffer provides stability
- Lower latency = higher chance of audio glitches

### "Can route application-specific audio"
- This app routes **all system audio**
- Cannot route only VLC or only Chrome
- Use Windows built-in app volume mixer for per-app volume

## Known Issues

1. **Net6.0 Warning**: App uses .NET 6.0 which is out of support. Future versions may update to .NET 8.0
2. **Bluetooth Latency**: Inherent limitation of Bluetooth technology
3. **No Visual Audio Levels**: Future feature request

## Reporting Bugs

When reporting bugs, use this template:

```
**Environment:**
- Windows Version:
- App Version:
- Audio Devices:

**Steps to Reproduce:**
1. 
2. 
3. 

**Expected Behavior:**

**Actual Behavior:**

**Screenshots:**

**Logs:**
```

---

**Still stuck?** Open an issue on GitHub and we'll help you out!
