using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovingPlatform : MonoBehaviour
{
    [SerializeField] Vector2[] points;
    [SerializeField] float Speed;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] int i = 0;
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (Vector2.Distance((Vector2)transform.position, points[i]) > 0.1f)
        {
            rb.linearVelocity = (points[i] - (Vector2)transform.position).normalized * Speed;
        }
        else
        {
            i++;
        }
        i = i % points.Length;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        foreach (var item in points)
        {
            Gizmos.DrawSphere(item, 0.5f);
        }
    }
}
