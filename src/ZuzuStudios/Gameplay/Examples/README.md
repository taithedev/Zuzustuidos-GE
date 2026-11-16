# C# behaviour samples

## Movement
- `AutoForwardBehaviour`
- `AutoBackwardBehaviour`
- `SidewaysBehaviour`
- `DiagonalBehaviour`

## Hover
- `SlowHoverBehaviour`
- `FastHoverBehaviour`
- `PlatformLiftBehaviour`
- `StrongBounceBehaviour`

## Orbit
- `WideOrbitBehaviour`
- `TightOrbitBehaviour`
- `VerticalOrbitBehaviour`
- `EllipseOrbitBehaviour`

## Input
- `WasdControllerBehaviour`
- `VerticalControllerBehaviour`
- `PrecisionControllerBehaviour`
- `BoostControllerBehaviour`

## Logic
- `LimitedMoverBehaviour`
- `WrapMoverBehaviour`
- `RampMoverBehaviour`
- `PulseMoverBehaviour`

## Patrol
- `PatrolXAxisBehaviour`
- `PatrolZAxisBehaviour`
- `ZigZagPatrolBehaviour`
- `StairPatrolBehaviour`

To use one: set an entity's `CSharpScript` JSON property to the class name (without .cs), rebuild the editor, then Play. All behaviour classes compile into the engine and are discovered by class name. This is the prototype's built-in behaviour model; arbitrary hot-loaded user C# assemblies are not implemented.
