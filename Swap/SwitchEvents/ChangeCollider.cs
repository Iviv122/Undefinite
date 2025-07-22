using UnityEngine;

public class ChangeCollider : SwitchEvent
{
    [SerializeField] Collider2D[] components;

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