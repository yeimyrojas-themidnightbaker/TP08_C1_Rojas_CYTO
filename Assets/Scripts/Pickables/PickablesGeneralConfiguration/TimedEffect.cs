[System.Serializable]

public class TimedEffect
{
    private float timeRemain;
    private float duration;
    public float TimeRemain => timeRemain;
    public bool IsActive => timeRemain > 0;
    public float Duration => duration;

    public void Activate(float newDuration)
    {
        duration = newDuration;
        timeRemain = newDuration;
    }

    public void Tick(float deltaTime)
    {
        if (timeRemain <= 0)
            return;
        timeRemain -= deltaTime;
    }
}