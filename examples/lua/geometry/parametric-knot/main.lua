-- ZuzuStudios Lua example: Move through a repeating 3D parametric shape.
-- Copy this file into your project's Assets/Scripts folder, then set LuaScript to its relative path.
local x0, y0, z0 = 0, 0, 0
function start()
  x0, y0, z0 = get_x(), get_y(), get_z()
end
function update(dt)
  local t=get_time()*.7
    set_position(x0+math.sin(t)*2,y0+math.cos(t*2),z0+math.sin(t*3)*1.5)
end
