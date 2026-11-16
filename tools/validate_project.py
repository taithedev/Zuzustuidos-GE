#!/usr/bin/env python3
"""Validate project manifests, scene JSON and relative Lua script references."""
import json
import pathlib
import sys

def main():
    project = pathlib.Path(sys.argv[1] if len(sys.argv) > 1 else "projects/StarterProject").resolve()
    manifest = json.loads((project / "project.json").read_text(encoding="utf-8"))
    assets = (project / "Assets").resolve()
    scene_files = list((assets / "Scenes").rglob("*.scene.json"))
    errors = []
    startup = (assets / manifest.get("StartupScene", "")).resolve()
    if not startup.is_file():
        errors.append(f"Missing startup scene: {startup}")
    for scene_file in scene_files:
        try:
            scene = json.loads(scene_file.read_text(encoding="utf-8"))
            for entity in scene["Entities"]:
                if entity.get("Primitive", "Cube") not in ("Cube", "Sphere"):
                    errors.append(f"{scene_file}: unsupported primitive {entity.get('Primitive')!r}")
                lua = entity.get("LuaScript")
                if lua:
                    script = (assets / lua).resolve()
                    if assets not in script.parents or not script.is_file():
                        errors.append(f"{scene_file}: invalid Lua script {lua}")
        except (ValueError, KeyError, TypeError) as error:
            errors.append(f"{scene_file}: {error}")
    print(f"Checked {len(scene_files)} scenes.")
    for error in errors: print("ERROR:", error)
    return 1 if errors else 0

if __name__ == "__main__":
    raise SystemExit(main())
