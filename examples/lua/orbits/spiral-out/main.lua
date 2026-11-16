-- ZuzuStudios Lua example: Expand a circular path over time.
-- Copy this file into your project's Assets/Scripts folder, then set LuaScript to its relative path.
local x0, y0, z0 = 0, 0, 0
function start()
  x0, y0, z0 = get_x(), get_y(), get_z()
end
function update(dt)
  local t=get_time()
    local radius=math.min(5,t*.4)
    set_position(x0+math.cos(t)*radius,y0,z0+math.sin(t)*radius)
end
