-- ZuzuStudios Lua example: Use WASD and Q/E to translate a hovering vehicle.
-- Copy this file into your project's Assets/Scripts folder, then set LuaScript to its relative path.
local x0, y0, z0 = 0, 0, 0
function start()
  x0, y0, z0 = get_x(), get_y(), get_z()
end
function update(dt)
  local s=5*dt
    if key_down('W') then translate(0,0,-s) end
    if key_down('S') then translate(0,0,s) end
    if key_down('A') then translate(-s,0,0) end
    if key_down('D') then translate(s,0,0) end
    if key_down('Q') then translate(0,-s,0) end
    if key_down('E') then translate(0,s,0) end
end
