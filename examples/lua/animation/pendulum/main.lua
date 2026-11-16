-- ZuzuStudios Lua example: Swing a primitive using two-axis position changes.
-- Copy this file into your project's Assets/Scripts folder, then set LuaScript to its relative path.
local x0, y0, z0 = 0, 0, 0
function start()
  x0, y0, z0 = get_x(), get_y(), get_z()
end
function update(dt)
  local t=get_time()
    local a=math.sin(t)*.7
    set_position(x0+2*math.sin(a),y0-2*(1-math.cos(a)),z0)
end
