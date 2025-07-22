using UnityEngine;

public class EyeMovement : MonoBehaviour
{
    [SerializeField] Movement movement;
    [SerializeField] float offset;
    [SerializeField] float t;
    Vector3 pivot;
    private void Awake() {
        pivot = transform.localPosition;
    }
    void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition,pivot + offset*new Vector3(movement.MoveDir.x,movement.MoveDir.y,0).normalized,t); 
    }
}
