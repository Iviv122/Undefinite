using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] float MoveSpeed;
    [SerializeField] float Accel;
    [SerializeField] float JumpPower;
    [Header("Bounce field")]
    [SerializeField] float Width;
    [SerializeField] float SideWidthCollider;
    [SerializeField] float SideHeightCollider;
    [Header("Jump field")]
    [SerializeField] float Height;
    [SerializeField] float WidthCollider;
    [SerializeField] float HeightCollider;
    [SerializeField] LayerMask ground;
    [Header("Import")]
    [SerializeField] Rigidbody2D rb;
    private float direction = 0;
    private bool start = false;
    public Vector2 MoveDir
    {
        get
        {
            return rb.linearVelocity;
        }
    }
    void Awake()
    {
    }
    public void OnMove(InputValue value)
    {
        // only left or right
        if (!start)
        {
            Vector2 input = value.Get<Vector2>();
            direction = (input.x > 0) ? 1 : -1;
            start = !start;
        }

    }
    private void Update()
    {
        direction = SeeWall() ? direction * -1 : direction;
    }
    public void FixedUpdate()
    {
        if (direction == 0)
        {
            return;
        }
        rb.linearVelocity = new Vector2(Mathf.Min(direction * MoveSpeed * Accel, direction * MoveSpeed), rb.linearVelocityY);
    }
    public void OnJump()
    {
        if (IsOnGround())
        {
            Jump();
        }
    }
    private void Jump()
    {
        rb.linearVelocity += Vector2.up * JumpPower;
    }
    private bool IsOnGround()
    {
        return Physics2D.BoxCast(transform.position, new Vector3(WidthCollider, HeightCollider), 0, Vector2.down, Height, ground);
    }
    private bool SeeWall()
    {
        return Physics2D.Raycast(transform.position, (direction < 1) ? Vector2.left : Vector2.right, WidthCollider, ground);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + Vector3.down * Height, new Vector3(WidthCollider, HeightCollider));
        Gizmos.DrawWireCube(transform.position + Vector3.left * Width, new Vector3(SideWidthCollider, SideHeightCollider));
        Gizmos.DrawWireCube(transform.position + Vector3.right * Width, new Vector3(SideWidthCollider, SideHeightCollider));
    }
}
