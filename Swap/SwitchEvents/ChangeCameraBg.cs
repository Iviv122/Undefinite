using UnityEngine;

public class ChangeCameraBg : SwitchEvent
{
    [SerializeField] Camera cam;
    [SerializeField] CameraBackgroundColor bg;
    private void Awake()
    {
        if (cam != null)
        {
            bg.color = cam.backgroundColor;
        }
    }
    public override void Switch()
    {
        if (cam != null)
        {
            cam.backgroundColor = (cam.backgroundColor == Color.white) ? Color.black : Color.white;
            bg.color = cam.backgroundColor;
        }
    }
}