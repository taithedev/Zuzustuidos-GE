-- ZuzuStudios Lua example: Rise first, then move horizontally.
-- Copy this file into your project's Assets/Scripts folder, then set LuaScript to its relative path.
local x0, y0, z0 = 0, 0, 0
function start()
  x0, y0, z0 = get_x(), get_y(), get_z()
end
function update(dt)
  if get_time()<3 then translate(0,2*dt,0) else translate(2*dt,0,0) end
end
