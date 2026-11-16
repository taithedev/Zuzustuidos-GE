-- ZuzuStudios Lua example: Hold B to stop automatic forward movement.
-- Copy this file into your project's Assets/Scripts folder, then set LuaScript to its relative path.
local x0, y0, z0 = 0, 0, 0
function start()
  x0, y0, z0 = get_x(), get_y(), get_z()
end
function update(dt)
  if not key_down('B') then translate(0,0,-3*dt) end
end
