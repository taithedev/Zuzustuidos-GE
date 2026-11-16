-- ZuzuStudios Lua example: Patrol a forward-moving zigzag lane.
-- Copy this file into your project's Assets/Scripts folder, then set LuaScript to its relative path.
local x0, y0, z0 = 0, 0, 0
function start()
  x0, y0, z0 = get_x(), get_y(), get_z()
end
function update(dt)
  local p=(get_time()*.5)%4
    set_position(x0+math.sin(p*math.pi)*2,y0,z0+p)
end
