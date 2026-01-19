# Build Instructions for Multi-Output Audio Router

## Prerequisites

- **Operating System**: Windows 10 or later (64-bit recommended)
- **.NET SDK**: .NET 6.0 SDK or later
- **IDE**: Visual Studio 2022 or Visual Studio Code (optional)
- **Git**: For version control

## Installing Prerequisites

### 1. Install .NET 6.0 SDK

Download and install from: https://dotnet.microsoft.com/download/dotnet/6.0

Verify installation:
```bash
dotnet --version
```

### 2. Install Visual Studio 2022 (Recommended)

Download from: https://visualstudio.microsoft.com/downloads/

During installation, select:
- .NET desktop development workload
- Windows desktop development with C++

**OR** use Visual Studio Code with C# extension

### 3. Install Git

Download from: https://git-scm.com/downloads

## Building the Application

### Method 1: Using Visual Studio

1. Open `MultiOutputAudioRouter.sln` in Visual Studio
2. Right-click on the solution in Solution Explorer
3. Select "Restore NuGet Packages"
4. Press `Ctrl+Shift+B` to build
5. Press `F5` to run with debugging, or `Ctrl+F5` to run without debugging

### Method 2: Using Command Line

```bash
# Clone the repository
git clone https://github.com/MohitSutharOfficial/Multi-Output-Audio-Router-for-Windows.git
cd Multi-Output-Audio-Router-for-Windows

# Restore NuGet packages
dotnet restore

# Build in Debug mode
dotnet build --configuration Debug

# Build in Release mode
dotnet build --configuration Release

# Run the application
dotnet run --project MultiOutputAudioRouter
```

## Build Configurations

### Debug Build
- Includes debugging symbols
- No optimizations
- Larger binary size
```bash
dotnet build --configuration Debug
```

### Release Build
- Optimized for performance
- Smaller binary size
- Ready for distribution
```bash
dotnet build --configuration Release
```

## Output Location

After building, the executable will be located at:

- **Debug**: `MultiOutputAudioRouter/bin/Debug/net6.0-windows/MultiOutputAudioRouter.exe`
- **Release**: `MultiOutputAudioRouter/bin/Release/net6.0-windows/MultiOutputAudioRouter.exe`

## Creating a Distributable Package

### Option 1: Self-Contained Deployment (Includes .NET Runtime)

```bash
# For 64-bit Windows
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true

# For 32-bit Windows
dotnet publish -c Release -r win-x86 --self-contained true -p:PublishSingleFile=true
```

Output: `MultiOutputAudioRouter/bin/Release/net6.0-windows/win-x64/publish/`

### Option 2: Framework-Dependent Deployment (Requires .NET Runtime)

```bash
dotnet publish -c Release -r win-x64 --self-contained false
```

This creates a smaller package but requires users to have .NET 6.0 Runtime installed.

## Common Build Issues

### Issue: "Project targets Windows, but is being built on Linux/Mac"

**Solution**: Build on Windows, or enable Windows targeting:
```xml
<EnableWindowsTargeting>true</EnableWindowsTargeting>
```

### Issue: "Could not load file or assembly NAudio"

**Solution**: Restore NuGet packages:
```bash
dotnet restore
```

### Issue: "The target framework 'net6.0-windows' is out of support"

**Note**: This is just a warning. The project will still build and run. To remove the warning, update to a newer framework like `net8.0-windows` in the project file.

### Issue: Build succeeds but app crashes on start

**Solution**: Ensure you're running on Windows with audio devices available.

## Running Tests

Currently, the project doesn't have automated tests. Manual testing steps:

1. Build and run the application
2. Verify device list loads
3. Select 2+ devices
4. Click "Start Routing"
5. Play audio from any application (VLC, browser, etc.)
6. Verify audio plays on all selected devices
7. Click "Stop Routing"
8. Verify audio returns to normal

## Debugging

### Using Visual Studio

1. Open solution in Visual Studio
2. Set breakpoints in code
3. Press `F5` to start debugging
4. Use debugging tools:
   - Locals window (View → Locals)
   - Watch window (Debug → Windows → Watch)
   - Output window (View → Output)

### Using Visual Studio Code

1. Install C# extension
2. Open folder in VS Code
3. Press `F5` to start debugging
4. Configure launch.json if needed

## Performance Profiling

To profile the application:

1. Build in Release mode
2. Run Windows Performance Analyzer
3. Or use Visual Studio Profiler (Debug → Performance Profiler)

## Code Analysis

Run static code analysis:
```bash
dotnet build /p:RunAnalyzers=true
```

## Clean Build

To clean build artifacts:
```bash
dotnet clean
```

## Troubleshooting Build Environment

### Verify .NET Installation
```bash
dotnet --info
```

### List Available SDKs
```bash
dotnet --list-sdks
```

### List Available Runtimes
```bash
dotnet --list-runtimes
```

## Additional Resources

- [.NET Documentation](https://docs.microsoft.com/dotnet/)
- [WPF Documentation](https://docs.microsoft.com/dotnet/desktop/wpf/)
- [NAudio Documentation](https://github.com/naudio/NAudio)
- [WASAPI Documentation](https://docs.microsoft.com/windows/win32/coreaudio/wasapi)

## Support

If you encounter build issues not covered here, please:
1. Check the Issues page on GitHub
2. Create a new issue with build logs
3. Include system information and .NET version
