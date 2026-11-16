-- ZuzuStudios Lua example: Swing a scene object in an X arc.
-- Copy this file into your project's Assets/Scripts folder, then set LuaScript to its relative path.
local x0, y0, z0 = 0, 0, 0
function start()
  x0, y0, z0 = get_x(), get_y(), get_z()
end
function update(dt)
  local t=get_time()
    set_position(x0+math.sin(t)*1.1,y0-math.abs(math.cos(t))*.1,z0)
end
