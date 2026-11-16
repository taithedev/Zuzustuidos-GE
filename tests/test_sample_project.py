"""Standard-library smoke tests for the sample game's JSON and references."""
import json
from pathlib import Path
import re
import unittest

ROOT = Path(__file__).resolve().parents[1]
PROJECT = ROOT / "projects" / "StarterProject"
SCENE_FILES = sorted((PROJECT / "Assets" / "Scenes").rglob("*.scene.json"))


class SampleProjectTests(unittest.TestCase):
    def test_manifest_startup_scene_exists(self):
        manifest = json.loads((PROJECT / "project.json").read_text(encoding="utf-8"))
        self.assertTrue((PROJECT / "Assets" / manifest["StartupScene"]).is_file())

    def test_scene_files_parse(self):
        self.assertGreaterEqual(len(SCENE_FILES), 10)
        for scene_file in SCENE_FILES:
            with self.subTest(scene=str(scene_file)):
                data = json.loads(scene_file.read_text(encoding="utf-8"))
                self.assertIsInstance(data["Entities"], list)
                self.assertTrue(data["Name"])

    def test_primitives_and_dimensions_are_supported(self):
        for scene_file in SCENE_FILES:
            scene = json.loads(scene_file.read_text(encoding="utf-8"))
            for entity in scene["Entities"]:
                with self.subTest(scene=str(scene_file), entity=entity["Name"]):
                    self.assertIn(entity["Primitive"], ("Cube", "Sphere"))
                    for component in ("X", "Y", "Z"):
                        self.assertGreater(entity["Size"][component], 0)

    def test_lua_references_exist(self):
        root = (PROJECT / "Assets").resolve()
        for scene_file in SCENE_FILES:
            scene = json.loads(scene_file.read_text(encoding="utf-8"))
            for entity in scene["Entities"]:
                relative = entity.get("LuaScript")
                if relative:
                    path = (root / relative).resolve()
                    self.assertIn(root, path.parents)
                    self.assertTrue(path.is_file(), str(path))

    def test_compiled_csharp_behaviours_exist(self):
        source_files = (ROOT / "src" / "ZuzuStudios").rglob("*.cs")
        names = set()
        for source_file in source_files:
            source = source_file.read_text(encoding="utf-8")
            names.update(re.findall(r"\bclass\s+(\w+)\s*:\s*Behaviour\b", source))
        self.assertGreaterEqual(len(names), 20)
        for scene_file in SCENE_FILES:
            scene = json.loads(scene_file.read_text(encoding="utf-8"))
            for entity in scene["Entities"]:
                name = entity.get("CSharpScript")
                if name:
                    self.assertIn(name, names, f"{scene_file}: {name}")


if __name__ == "__main__":
    unittest.main()
