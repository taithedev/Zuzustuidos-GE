function update(dt)
  local speed = 4 * dt
  if key_down("A") then translate(-speed, 0, 0) end
  if key_down("D") then translate(speed, 0, 0) end
  if key_down("W") then translate(0, 0, -speed) end
  if key_down("S") then translate(0, 0, speed) end
end
