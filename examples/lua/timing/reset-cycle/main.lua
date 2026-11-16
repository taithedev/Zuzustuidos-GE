-- ZuzuStudios Lua example: Restart a scripted position every five seconds.
-- Copy this file into your project's Assets/Scripts folder, then set LuaScript to its relative path.
local x0, y0, z0 = 0, 0, 0
function start()
  x0, y0, z0 = get_x(), get_y(), get_z()
end
function update(dt)
  local t=get_time()%5
    set_position(x0+t,y0,z0)
end
