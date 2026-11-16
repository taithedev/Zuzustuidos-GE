-- ZuzuStudios Lua example: Move forward while weaving side to side.
-- Copy this file into your project's Assets/Scripts folder, then set LuaScript to its relative path.
local x0, y0, z0 = 0, 0, 0
function start()
  x0, y0, z0 = get_x(), get_y(), get_z()
end
function update(dt)
  translate(math.sin(get_time() * 5) * dt * 2, 0, -2 * dt)
end
