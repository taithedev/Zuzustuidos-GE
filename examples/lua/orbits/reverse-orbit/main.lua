-- ZuzuStudios Lua example: Circle the opposite direction.
-- Copy this file into your project's Assets/Scripts folder, then set LuaScript to its relative path.
local x0, y0, z0 = 0, 0, 0
function start()
  x0, y0, z0 = get_x(), get_y(), get_z()
end
function update(dt)
  local t=-get_time()*1.2
    set_position(x0+math.cos(t)*2.5,y0,z0+math.sin(t)*2.5)
end
