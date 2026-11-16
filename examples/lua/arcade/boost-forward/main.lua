-- ZuzuStudios Lua example: Hold W to travel faster.
-- Copy this file into your project's Assets/Scripts folder, then set LuaScript to its relative path.
local x0, y0, z0 = 0, 0, 0
function start()
  x0, y0, z0 = get_x(), get_y(), get_z()
end
function update(dt)
  local speed=key_down('W') and 6 or 1
    translate(0,0,-speed*dt)
end
