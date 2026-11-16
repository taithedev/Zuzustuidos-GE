# Asset smoke tests

Run `python -m unittest discover -s tests -v` from the repository root. These tests verify that shipped JSON scenes parse, the project manifest points to an existing scene, primitives have positive sizes, referenced Lua assets exist, and C# behaviour names used by sample scenes are implemented.

The GitHub Actions `Validate project assets` workflow runs these checks on every push and pull request. This is a basic validation suite, not comprehensive game engine integration testing.
