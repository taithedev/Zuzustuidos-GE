-- ZuzuStudios Lua example: Patrol four sides of a square.
-- Copy this file into your project's Assets/Scripts folder, then set LuaScript to its relative path.
local x0, y0, z0 = 0, 0, 0
function start()
  x0, y0, z0 = get_x(), get_y(), get_z()
end
function update(dt)
  local t=(get_time()*.3)%4
    local a= t<1 and t or (t<2 and 1 or (t<3 and 3-t or 0))
    local b= t<1 and 0 or (t<2 and t-1 or (t<3 and 1 or 4-t))
    set_position(x0+a*3,y0,z0+b*3)
end
