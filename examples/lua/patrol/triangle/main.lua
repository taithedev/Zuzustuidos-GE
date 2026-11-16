-- ZuzuStudios Lua example: Follow a three-point triangular patrol.
-- Copy this file into your project's Assets/Scripts folder, then set LuaScript to its relative path.
local x0, y0, z0 = 0, 0, 0
function start()
  x0, y0, z0 = get_x(), get_y(), get_z()
end
function update(dt)
  local p=(get_time()*.3)%3
    local a=p<1 and p or (p<2 and 2-p or 0)
    local b=p<1 and 0 or (p<2 and p-1 or 3-p)
    set_position(x0+a*3,y0,z0+b*3)
end
