# LeetCode Dailies (.NET)

Personal repository for pushing code solutions to LeetCode Daily problems. The goal is consistency: one small solution per day. Well, hopefully...

## Tech Stack
- .NET 9.0
- C# 12

## Repository Layout
- `LeetCodeDailies/` — Main .NET project containing daily solutions
  - `<Month>/<DD-ProblemName>/` — Example daily problem folder where DD is day of month
    - `SomeRunner.cs` — Problem-specific runner used by `Program.cs`

## Running Locally
Prerequisite: Install the .NET 9 SDK.

- Build: `dotnet build LeetCodeDailies`
- Run: `dotnet run --project LeetCodeDailies`

`Program.cs` calls the current problem runner (e.g., `SudokuRunner.Run()`); update this as new dailies are added.

## Adding a New Daily
1. Create a new folder under `LeetCodeDailies/<Month>/<DD-ProblemName>/`.
2. Add your solution files and a small runner class with a static `Run()` entry.
3. Point `Program.cs` to your new runner.
