using UnityEngine;

public class ChangeSprite : SwitchEvent
{
    [SerializeField] Sprite First;
    [SerializeField] Sprite Second;
    [SerializeField] SpriteRenderer spriteRenderer;

    public override void Switch()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = (spriteRenderer.sprite == First) ? Second : First;
        }
    }
}