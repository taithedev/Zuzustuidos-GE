-- ZuzuStudios Lua example: Slowly drift in XZ.
-- Copy this file into your project's Assets/Scripts folder, then set LuaScript to its relative path.
local x0, y0, z0 = 0, 0, 0
function start()
  x0, y0, z0 = get_x(), get_y(), get_z()
end
function update(dt)
  local t=get_time()
    set_position(x0+math.sin(t*.4)*.35,y0,z0+math.cos(t*.5)*.35)
end
