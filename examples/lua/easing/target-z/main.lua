-- ZuzuStudios Lua example: Smoothly approach a target Z coordinate.
-- Copy this file into your project's Assets/Scripts folder, then set LuaScript to its relative path.
local x0, y0, z0 = 0, 0, 0
function start()
  x0, y0, z0 = get_x(), get_y(), get_z()
end
function update(dt)
  local z=get_z()
    set_position(get_x(),get_y(),z+(z0-3-z)*(1-math.exp(-4*dt)))
end
