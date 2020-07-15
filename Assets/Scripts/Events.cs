using System;

public class Events
{
    public static Action<int> AddScore;
    public static Action LoadNextLevel;
    public static Action ResetLevels;
    public static Action GameOver;
}
