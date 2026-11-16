# Contributing to ZuzuStudios

Contributions should address a real user need. Before opening a PR:

1. Create a focused branch rather than changing unrelated systems.
2. Add a runnable example or tutorial when expanding scripting features.
3. Run `dotnet build src/ZuzuStudios/ZuzuStudios.csproj -c Release`.
4. Run `python tools/validate_project.py projects/StarterProject`.
5. Be clear about what works today versus what is planned.

Target .NET 8; avoid extra dependencies without a documented reason. Do not commit binaries or secret keys. Use GitHub Issues to discuss large architectural changes first.
