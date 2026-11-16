-- ZuzuStudios Lua example: Move up steps in a repeating staircase.
-- Copy this file into your project's Assets/Scripts folder, then set LuaScript to its relative path.
local x0, y0, z0 = 0, 0, 0
function start()
  x0, y0, z0 = get_x(), get_y(), get_z()
end
function update(dt)
  local step=math.floor(get_time())%5
    set_position(x0+step,y0+step*.5,z0)
end
