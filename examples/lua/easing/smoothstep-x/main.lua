-- ZuzuStudios Lua example: Ease between X endpoints with smoothstep.
-- Copy this file into your project's Assets/Scripts folder, then set LuaScript to its relative path.
local x0, y0, z0 = 0, 0, 0
function start()
  x0, y0, z0 = get_x(), get_y(), get_z()
end
function update(dt)
  local t=(math.sin(get_time())+1)*.5
    local u=t*t*(3-2*t)
    set_position(x0+u*4,y0,z0)
end
