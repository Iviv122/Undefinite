using System;
using UnityEngine;

[CreateAssetMenu(fileName = "SwitchStateBus", menuName = "SwitchStateBus", order = 0)]
public class SwitchStateBus : ScriptableObject
{
    public event Action OnSwitch;
    public bool state;
    public void Switch()
    {
        OnSwitch?.Invoke();
    }
}
