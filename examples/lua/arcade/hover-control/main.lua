-- ZuzuStudios Lua example: Raise or lower hover height using R and F.
-- Copy this file into your project's Assets/Scripts folder, then set LuaScript to its relative path.
local x0, y0, z0 = 0, 0, 0
function start()
  x0, y0, z0 = get_x(), get_y(), get_z()
end
function update(dt)
  if key_down('R') then translate(0,2*dt,0) end
    if key_down('F') then translate(0,-2*dt,0) end
end
