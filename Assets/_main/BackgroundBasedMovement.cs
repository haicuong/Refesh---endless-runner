using System;
using UnityEngine;

public static class BackgroundBasedMovement
{
    private static float speedMultiple = 1f;
    public static float SpeedMultiple => speedMultiple;

    public static event Action OnSpeedMultipleChange;

    public static void SetSpeedMultiple(float multiple)
    {
        speedMultiple = Mathf.Max(multiple, 0);
        OnSpeedMultipleChange?.Invoke();
    }
}
