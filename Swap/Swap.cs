using NaughtyAttributes;
using UnityEngine;

public class Swap : MonoBehaviour
{
    [SerializeField] SwitchStateBus bus;
    [SerializeField] SwitchEvent[] switchEvents;
    [Button]
    public void Change()
    {
        Switch();
    }
    public void Awake()
    {
        bus.OnSwitch += Switch;
    }
    public void Switch()
    {
        foreach (var item in switchEvents)
        {
            item.Switch();
        }
    }
}


