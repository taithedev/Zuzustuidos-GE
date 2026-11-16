#!/usr/bin/env bash
set -euo pipefail
cd "$(dirname "$0")"
dotnet run --project src/ZuzuStudios/ZuzuStudios.csproj -- --project projects/StarterProject "$@"
