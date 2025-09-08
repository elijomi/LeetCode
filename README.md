# LeetCode Problems (.NET)

Personal repository for pushing code solutions to LeetCode problems. The goal is consistency: one small solution per day. Well, hopefully...

## Tech Stack
- .NET 9.0
- C# 12

## Repository Layout
- `src` — Main .NET project
  - `LeetCodeRunners` — Folder containing problem specific runners
  - `LeetCodeProblems` — Folder containing implementations of solutions
    - `Top100Liked` — Folder containing solutions for problems from the LeetCode collection 'Top 100 Liked'
    - `Dailies` — Folder containing solutions for daily LeetCode problems
    - `<Month>/<DD-ProblemName>/` — Example daily problem folder where DD is day of month

## Running Locally
Prerequisite: Install the .NET 9 SDK.

- Build: `dotnet build LeetCode`
- Run: `dotnet run --project LeetCode`

`Program.cs` calls the current problem runner (e.g., `SudokuRunner.Run()`); update this as new dailies are added.

## Adding a New Daily
1. Create a new folder under `src/LeetCodeProblems/Dailies/<Month>/<DD-ProblemName>/` and add your solution.
2. Create a small runner class under `src/LeetCodeRunners/` with a static `Run()` entry.
3. Point `Program.cs` to your new runner.
4. Add tests under `tests/`
