-- ZuzuStudios Lua example: Smoothly approach a target Y coordinate.
-- Copy this file into your project's Assets/Scripts folder, then set LuaScript to its relative path.
local x0, y0, z0 = 0, 0, 0
function start()
  x0, y0, z0 = get_x(), get_y(), get_z()
end
function update(dt)
  local y=get_y()
    set_y(y+(y0+2-y)*(1-math.exp(-4*dt)))
end
