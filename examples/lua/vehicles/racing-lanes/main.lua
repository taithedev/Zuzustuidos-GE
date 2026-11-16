-- ZuzuStudios Lua example: Choose among constrained X lanes with A/D.
-- Copy this file into your project's Assets/Scripts folder, then set LuaScript to its relative path.
local x0, y0, z0 = 0, 0, 0
function start()
  x0, y0, z0 = get_x(), get_y(), get_z()
end
function update(dt)
  local speed=8*dt
    if key_down('W') then translate(0,0,-speed) end
    local lane=get_x()
    if key_down('A') then lane=lane-4*dt end
    if key_down('D') then lane=lane+4*dt end
    set_position(math.max(x0-3,math.min(x0+3,lane)),get_y(),get_z())
end
