-- ZuzuStudios Lua example: A cycloid-like rolling curve.
-- Copy this file into your project's Assets/Scripts folder, then set LuaScript to its relative path.
local x0, y0, z0 = 0, 0, 0
function start()
  x0, y0, z0 = get_x(), get_y(), get_z()
end
function update(dt)
  local t=get_time()*.7
    set_position(x0+t-math.sin(t),y0+1-math.cos(t),z0)
end
