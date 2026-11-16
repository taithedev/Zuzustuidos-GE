-- ZuzuStudios Lua example: Move with four arrow keys.
-- Copy this file into your project's Assets/Scripts folder, then set LuaScript to its relative path.
local x0, y0, z0 = 0, 0, 0
function start()
  x0, y0, z0 = get_x(), get_y(), get_z()
end
function update(dt)
  local s = 4 * dt
    if key_down('Up') then translate(0,0,-s) end
    if key_down('Down') then translate(0,0,s) end
    if key_down('Left') then translate(-s,0,0) end
    if key_down('Right') then translate(s,0,0) end
end
