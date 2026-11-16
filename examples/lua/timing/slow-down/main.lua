-- ZuzuStudios Lua example: Gradually slow translation to a stop.
-- Copy this file into your project's Assets/Scripts folder, then set LuaScript to its relative path.
local x0, y0, z0 = 0, 0, 0
function start()
  x0, y0, z0 = get_x(), get_y(), get_z()
end
function update(dt)
  local s=math.max(0,4-get_time()*.8)
    translate(0,0,-s*dt)
end
