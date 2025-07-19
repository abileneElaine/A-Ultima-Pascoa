using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerVelocity = 10f;
    public float jumpForce = 10f;
    public PlayerAnimationController playerAnim;
    public Rigidbody2D rb;

    private bool isGrounded = true;

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        // Pulo
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
            playerAnim.SetIsJumping(true);
        }

        // Só anda se estiver no chão e não pulando
        if (isGrounded && Mathf.Abs(horizontal) > 0)
        {
            transform.position += transform.right * horizontal * (Time.deltaTime * playerVelocity);

            // Flip
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Sign(horizontal) * Mathf.Abs(scale.x);
            transform.localScale = scale;

            playerAnim.SetIsWalking(true);
        }
        else
        {
            playerAnim.SetIsWalking(false);
        }
    }


    // Detecta se está no chão usando colisão
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
            playerAnim.SetIsJumping(false);
        }
    }
}