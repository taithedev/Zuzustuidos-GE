-- ZuzuStudios Lua example: Follow a straight fixed-speed rail path.
-- Copy this file into your project's Assets/Scripts folder, then set LuaScript to its relative path.
local x0, y0, z0 = 0, 0, 0
function start()
  x0, y0, z0 = get_x(), get_y(), get_z()
end
function update(dt)
  local t=get_time()%8
    set_position(x0+t*.75,y0,z0)
end
