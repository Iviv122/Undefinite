using UnityEngine;

[CreateAssetMenu(fileName = "CameraBackgroundColor", menuName = "CameraBackgroundColor", order = 0)]
public class CameraBackgroundColor : ScriptableObject
{
    public Color color { get; set; }
}
