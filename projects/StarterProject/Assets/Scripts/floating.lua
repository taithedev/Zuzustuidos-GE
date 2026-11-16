local base_height = 1.5
function start()
  base_height = get_y()
  print_log("Floating sphere ready")
end
function update(dt)
  set_y(base_height + math.sin(get_time() * 2) * 0.65)
end
