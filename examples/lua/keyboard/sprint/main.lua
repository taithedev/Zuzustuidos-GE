-- ZuzuStudios Lua example: Hold LeftShift to move more quickly.
-- Copy this file into your project's Assets/Scripts folder, then set LuaScript to its relative path.
local x0, y0, z0 = 0, 0, 0
function start()
  x0, y0, z0 = get_x(), get_y(), get_z()
end
function update(dt)
  local speed = key_down('LeftShift') and 8 or 3
    if key_down('W') then translate(0,0,-speed*dt) end
end
