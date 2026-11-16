-- ZuzuStudios Lua example: Sum multiple wave components.
-- Copy this file into your project's Assets/Scripts folder, then set LuaScript to its relative path.
local x0, y0, z0 = 0, 0, 0
function start()
  x0, y0, z0 = get_x(), get_y(), get_z()
end
function update(dt)
  local t=get_time()
    set_y(y0+.4*math.sin(t)+.25*math.sin(t*3)+.1*math.sin(t*7))
end
