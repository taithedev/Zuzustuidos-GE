-- ZuzuStudios Lua example: Constant-speed depth sweep with reversals.
-- Copy this file into your project's Assets/Scripts folder, then set LuaScript to its relative path.
local x0, y0, z0 = 0, 0, 0
function start()
  x0, y0, z0 = get_x(), get_y(), get_z()
end
function update(dt)
  local p=(get_time()*.6)%2
    set_position(x0,y0,z0+(1-math.abs(p-1))*5)
end
