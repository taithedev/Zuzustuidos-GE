# Write frame-independent motion

**Lesson 3 / lua**

## Goal

Use delta time to keep movement consistent at different frame rates.

## Try it

```text
function update(dt) translate(4*dt,0,0) end
```

## What to know

Do not move four world units every frame; that would depend on FPS.

## Continue

Go back to the [tutorial index](../../README.md) and choose another lesson, or try an [example Lua script](../../../../examples/lua/README.md).
