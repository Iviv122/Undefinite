using UnityEngine;

public class ChangeEffectColor : SwitchEvent
{
    [SerializeField] ParticleSystem particle;
    [SerializeField] CameraBackgroundColor cameraBackgroundColor;
    private void Awake() {
        Switch();
    }
    public override void Switch()
    {

        if (particle != null && cameraBackgroundColor != null)
        {
            var main = particle.main;
            main.startColor = (cameraBackgroundColor.color == Color.white) ? Color.black : Color.white;
        }
    }
}
