-- ZuzuStudios Lua example: Alternate X, Y and Z motion every second.
-- Copy this file into your project's Assets/Scripts folder, then set LuaScript to its relative path.
local x0, y0, z0 = 0, 0, 0
function start()
  x0, y0, z0 = get_x(), get_y(), get_z()
end
function update(dt)
  local phase=math.floor(get_time())%3
    if phase==0 then translate(dt,0,0)
    elseif phase==1 then translate(0,dt,0)
    else translate(0,0,dt) end
end
