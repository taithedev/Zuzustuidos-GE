-- ZuzuStudios Lua example: Exponentially ease to a position in 3D.
-- Copy this file into your project's Assets/Scripts folder, then set LuaScript to its relative path.
local x0, y0, z0 = 0, 0, 0
function start()
  x0, y0, z0 = get_x(), get_y(), get_z()
end
function update(dt)
  local k=1-math.exp(-2*dt)
    set_position(get_x()+(x0+2-get_x())*k,get_y()+(y0+1-get_y())*k,get_z()+(z0-2-get_z())*k)
end
