-- ZuzuStudios Lua example: Hold J or L to dash sideways.
-- Copy this file into your project's Assets/Scripts folder, then set LuaScript to its relative path.
local x0, y0, z0 = 0, 0, 0
function start()
  x0, y0, z0 = get_x(), get_y(), get_z()
end
function update(dt)
  if key_down('J') then translate(-6*dt,0,0) end
    if key_down('L') then translate(6*dt,0,0) end
end
