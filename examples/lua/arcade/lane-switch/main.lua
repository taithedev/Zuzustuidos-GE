-- ZuzuStudios Lua example: Use A/D to move between constrained lanes.
-- Copy this file into your project's Assets/Scripts folder, then set LuaScript to its relative path.
local x0, y0, z0 = 0, 0, 0
function start()
  x0, y0, z0 = get_x(), get_y(), get_z()
end
function update(dt)
  local move=0
    if key_down('A') then move=-1 end
    if key_down('D') then move=1 end
    local x=math.max(x0-3,math.min(x0+3,get_x()+move*5*dt))
    set_position(x,get_y(),get_z())
end
