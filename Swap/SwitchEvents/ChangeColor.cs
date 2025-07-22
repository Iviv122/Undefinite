using UnityEngine;

public class ChangeColor : SwitchEvent
{
    [SerializeField] SpriteRenderer spriteRenderer;

    public override void Switch()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = (spriteRenderer.color == Color.white) ? Color.black : Color.white;
        }
    }
}
