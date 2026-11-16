-- ZuzuStudios Lua example: Repeated ramp along the X axis.
-- Copy this file into your project's Assets/Scripts folder, then set LuaScript to its relative path.
local x0, y0, z0 = 0, 0, 0
function start()
  x0, y0, z0 = get_x(), get_y(), get_z()
end
function update(dt)
  local phase=(get_time()*.4)%1
    set_position(x0+phase*4,y0,z0)
end
