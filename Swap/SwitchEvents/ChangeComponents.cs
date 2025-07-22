using UnityEngine;

public class ChangeComponents : SwitchEvent
{
    [SerializeField] MonoBehaviour[] components;
    public override void Switch()
    {
        foreach (var item in components)
        {
            if (item != null)
            {
                item.enabled = !item.enabled;
            }
        }

    }
}
