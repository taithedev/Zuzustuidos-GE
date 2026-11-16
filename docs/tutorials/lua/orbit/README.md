# Animate a circular path

**Lesson 5 / lua**

## Goal

Capture an initial position in start() and use get_time() to calculate a circle.

## Try it

```text
function start() x,y,z=get_x(),get_y(),get_z() end
function update(dt)
  local t=get_time()
  set_position(x+math.cos(t)*2,y,z+math.sin(t)*2)
end
```

## What to know

Use absolute starting coordinates to avoid accumulating drift.

## Continue

Go back to the [tutorial index](../../../README.md) and choose another lesson, or try an [example Lua script](../../../../../examples/lua/README.md).
