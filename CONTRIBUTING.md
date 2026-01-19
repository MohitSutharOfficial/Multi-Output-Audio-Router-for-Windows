# Contributing to Multi-Output Audio Router

Thank you for your interest in contributing to the Multi-Output Audio Router project! This document provides guidelines and instructions for contributing.

## Getting Started

1. Fork the repository
2. Clone your fork locally
3. Create a new branch for your feature or bug fix
4. Make your changes
5. Test your changes thoroughly
6. Submit a pull request

## Development Environment Setup

### Prerequisites
- Windows 10 or later (for testing)
- Visual Studio 2022 or later
- .NET 6.0 SDK or later
- Git

### Building the Project

```bash
# Clone the repository
git clone https://github.com/MohitSutharOfficial/Multi-Output-Audio-Router-for-Windows.git
cd Multi-Output-Audio-Router-for-Windows

# Restore dependencies
dotnet restore

# Build
dotnet build --configuration Debug

# Run
dotnet run --project MultiOutputAudioRouter
```

## Code Style Guidelines

- Follow standard C# naming conventions
- Use meaningful variable and method names
- Add XML documentation comments for public APIs
- Keep methods focused and concise
- Use async/await for I/O operations where appropriate

## Testing

Before submitting a pull request:

1. Build the project successfully
2. Test with at least 2 different audio devices
3. Test with VLC or other media players
4. Verify start/stop functionality works correctly
5. Check for memory leaks during extended use
6. Test error handling with disconnected devices

## Pull Request Process

1. Update the README.md if needed
2. Update documentation for any changed functionality
3. Ensure your PR description clearly describes the changes
4. Link any related issues in your PR description
5. Wait for code review and address feedback

## Reporting Bugs

When reporting bugs, please include:

- Windows version
- Application version
- Steps to reproduce
- Expected behavior
- Actual behavior
- Screenshots if applicable
- Audio device information

## Feature Requests

Feature requests are welcome! Please:

- Clearly describe the feature
- Explain the use case
- Provide examples if possible
- Consider implementation complexity

## Code of Conduct

- Be respectful and inclusive
- Provide constructive feedback
- Focus on the code, not the person
- Help create a welcoming environment

## License

By contributing, you agree that your contributions will be licensed under the same license as the project (MIT License).

## Questions?

Feel free to open an issue for any questions about contributing.
