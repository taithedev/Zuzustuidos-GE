-- ZuzuStudios Lua example: Slide left and right along X.
-- Copy this file into your project's Assets/Scripts folder, then set LuaScript to its relative path.
local x0, y0, z0 = 0, 0, 0
function start()
  x0, y0, z0 = get_x(), get_y(), get_z()
end
function update(dt)
  set_position(x0+math.sin(get_time()*2)*2,y0,z0)
end
