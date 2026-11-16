namespace ZuzuStudios.Diagnostics;

public sealed class FrameTimer
{
    public double ElapsedSeconds { get; private set; }
    public int FrameCount { get; private set; }
    public float LastDeltaSeconds { get; private set; }
    public void Advance(float dt)
    {
        LastDeltaSeconds = Math.Clamp(dt, 0, .1f);
        ElapsedSeconds += LastDeltaSeconds;
        FrameCount++;
    }
    public void Reset() { ElapsedSeconds = 0; FrameCount = 0; LastDeltaSeconds = 0; }
}
