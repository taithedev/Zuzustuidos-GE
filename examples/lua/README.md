# Lua recipe library

These 96 examples use only APIs currently supported by the engine. Each recipe lives in its own folder and has a runnable `main.lua`. To try one, copy the script into `projects/StarterProject/Assets/Scripts/`, set an entity's `LuaScript` in the scene JSON to `Scripts/yourfile.lua`, and press F5.

Available groups:
- **movement**: `forward`, `backward`, `left`, `right`, `rise`, `sink`, `diagonal`, `zigzag`
- **keyboard**: `wasd`, `arrows`, `vertical-qe`, `sprint`, `space-rise`, `axis-select`, `camera-plane`, `slow-precision`
- **oscillation**: `vertical-sine`, `vertical-cosine`, `horizontal-sine`, `depth-sine`, `figure-eight`, `double-bounce`, `triangle-wave`, `wave-mix`
- **orbits**: `circle-xz`, `circle-xy`, `circle-yz`, `ellipse`, `reverse-orbit`, `orbital-bob`, `spiral-out`, `shrinking-orbit`
- **patrol**: `two-points-x`, `two-points-z`, `square`, `triangle`, `staircase`, `zigzag-path`, `sweep-x`, `sweep-z`
- **easing**: `target-x`, `target-y`, `target-z`, `target-xyz`, `smoothstep-x`, `smoothstep-y`, `ease-in-cycle`, `ease-out-cycle`
- **timing**: `delayed-launch`, `pulsed-motion`, `every-third-second`, `speed-ramp`, `slow-down`, `staged-rise`, `reset-cycle`, `phase-mover`
- **arcade**: `jump-hold`, `boost-forward`, `brake`, `side-dash`, `hover-control`, `guard-range`, `boundary-wrap`, `lane-switch`
- **ambient**: `subtle-hover`, `gentle-drift`, `wind-gust`, `floating-collectible`, `pulsed-platform`, `tide`, `particle-motion`, `ceiling-sway`
- **geometry**: `lemniscate`, `lissajous`, `helix`, `cycloid`, `sawtooth`, `diamond`, `sine-stack`, `parametric-knot`
- **vehicles**: `car-forward`, `car-reverse`, `hovercraft`, `elevator`, `rail-cart`, `drone-bob`, `patrol-drone`, `racing-lanes`
- **animation**: `bounce`, `float`, `tremor`, `sway`, `drop-recover`, `rise-repeat`, `pendulum`, `orbit-float`

Lua uses current-world position, not transforms or rigid bodies. These are movement examples, not complete player controllers, physics, or animation systems.
