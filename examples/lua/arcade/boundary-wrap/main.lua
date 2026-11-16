-- ZuzuStudios Lua example: Wrap back to start after moving forward.
-- Copy this file into your project's Assets/Scripts folder, then set LuaScript to its relative path.
local x0, y0, z0 = 0, 0, 0
function start()
  x0, y0, z0 = get_x(), get_y(), get_z()
end
function update(dt)
  if get_z()<z0-8 then set_position(x0,get_y(),z0) else translate(0,0,-4*dt) end
end
