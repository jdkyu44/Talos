using UnityEngine;

public enum AttackType
{
    Right,
    Left,
    Up,
    Down
}

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public bool isGrounded = true;
    Rigidbody2D rb;

    public bool isFacingRight = true;
    public bool isFacingLeft = false;

    public AttackType attackType;

    PlayerAttacked playerAttacked;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAttacked = GetComponent<PlayerAttacked>();
    }

    private void Update()
    {
        if (playerAttacked.isKnockedback == true)
            return;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            isFacingRight = true;
            isFacingLeft = false;
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            isFacingLeft = true;
            isFacingRight = false;
        }

        Move();
        Jump();

        attackType = GetAttackType();
    }

    private void Move()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(moveSpeed * moveInput, rb.linearVelocity.y);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    public AttackType GetAttackType()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            return AttackType.Up;

        if (Input.GetKey(KeyCode.DownArrow) && !isGrounded)
            return AttackType.Down;

        return isFacingRight ? AttackType.Right : AttackType.Left;
    }
}