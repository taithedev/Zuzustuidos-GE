# Learn start and update

**Lesson 1 / lua**

## Goal

A Lua script may define start() (one-time setup) and update(dt) (each simulation frame).

## Try it

```text
function start() print_log('Ready') end
function update(dt) translate(0,0,-2*dt) end
```

## What to know

dt measures seconds since the last frame. Multiply frame-based speed by dt.

## Continue

Go back to the [tutorial index](../../../README.md) and choose another lesson, or try an [example Lua script](../../../../../examples/lua/README.md).
