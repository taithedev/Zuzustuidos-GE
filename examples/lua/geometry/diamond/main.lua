-- ZuzuStudios Lua example: Trace a diamond in the XZ plane.
-- Copy this file into your project's Assets/Scripts folder, then set LuaScript to its relative path.
local x0, y0, z0 = 0, 0, 0
function start()
  x0, y0, z0 = get_x(), get_y(), get_z()
end
function update(dt)
  local t=(get_time()*.6)%4
    local a=t<1 and t or (t<2 and 2-t or (t<3 and 2-t or t-4))
    local b=t<1 and 1-t or (t<2 and t-1 or (t<3 and t-1 or 4-t))
    set_position(x0+a*2,y0,z0+b*2)
end
