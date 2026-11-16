-- ZuzuStudios Lua example: Smoothly approach a target X coordinate.
-- Copy this file into your project's Assets/Scripts folder, then set LuaScript to its relative path.
local x0, y0, z0 = 0, 0, 0
function start()
  x0, y0, z0 = get_x(), get_y(), get_z()
end
function update(dt)
  local x=get_x()
    local k=1-math.exp(-3*dt)
    set_position(x+(x0+3-x)*k,get_y(),get_z())
end
