-- ZuzuStudios Lua example: Move during alternating one-second windows.
-- Copy this file into your project's Assets/Scripts folder, then set LuaScript to its relative path.
local x0, y0, z0 = 0, 0, 0
function start()
  x0, y0, z0 = get_x(), get_y(), get_z()
end
function update(dt)
  if math.floor(get_time())%2==0 then translate(2*dt,0,0) end
end
