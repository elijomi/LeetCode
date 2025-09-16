# LeetCode Problems (.NET & Go)
Personal repository for pushing code solutions to LeetCode problems. The goal is consistency: one small solution per day. Well, hopefully...

## Tech Stack
- .NET 9.0
- C# 12
- Go 1.25.1

## Repository Layout
- `src` — Main .NET project
  - `GoAlgos` — Folder containing Go mod, solutions & tests
    - `dailies` — Folder containing solutions for daily LeetCode problems in Go
    - `<month>/<DD-problem_name>/` — Example daily problem folder where DD is day of month
  - `CSharpLib` — Folder containing C# solutions
    - `Dailies` — Folder containing solutions for daily LeetCode problems in C#
      - `<Month>/<DD-ProblemName>/` — Example daily problem folder where DD is day of month
    - `Top100Liked` — Folder containing solutions for problems from the LeetCode collection 'Top 100 Liked' in C#
  
- `tests` — Main .NET test project
  - `CSharpTests` — Folder containing C# test
    - `Dailies` — Folder containing C# tests for daily LeetCode problems
      - `<Month>` — Daily problem tests sorted under their respective month
    - `Top100Liked` — Folder containing C# tests for problems from the LeetCode collection 'Top 100 Liked'