-- ZuzuStudios Lua example: Small rapid positional vibration.
-- Copy this file into your project's Assets/Scripts folder, then set LuaScript to its relative path.
local x0, y0, z0 = 0, 0, 0
function start()
  x0, y0, z0 = get_x(), get_y(), get_z()
end
function update(dt)
  local t=get_time()
    set_position(x0+math.sin(t*27)*.06,y0,z0+math.cos(t*29)*.06)
end
