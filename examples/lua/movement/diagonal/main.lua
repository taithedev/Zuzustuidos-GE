-- ZuzuStudios Lua example: Move along X and Z at a normalized diagonal speed.
-- Copy this file into your project's Assets/Scripts folder, then set LuaScript to its relative path.
local x0, y0, z0 = 0, 0, 0
function start()
  x0, y0, z0 = get_x(), get_y(), get_z()
end
function update(dt)
  local step = 2.0 * dt / math.sqrt(2)
    translate(step, 0, -step)
end
