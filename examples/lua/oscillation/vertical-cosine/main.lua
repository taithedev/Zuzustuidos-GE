-- ZuzuStudios Lua example: Vertical hover with a quarter-cycle offset.
-- Copy this file into your project's Assets/Scripts folder, then set LuaScript to its relative path.
local x0, y0, z0 = 0, 0, 0
function start()
  x0, y0, z0 = get_x(), get_y(), get_z()
end
function update(dt)
  set_y(y0 + math.cos(get_time()*2)*.8)
end
