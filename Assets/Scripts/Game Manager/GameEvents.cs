using System;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents instance;

    public event Action <Vector3> onSetCheckpoint;
    public static event Action<float> onUpdateHealthBar;

    private void Awake()
    {
        instance = this;
    }

    public void UpdateHealthBar(float current, float max)
    {
        onUpdateHealthBar?.Invoke(current / max);
    }
}
