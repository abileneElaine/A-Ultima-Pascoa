using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerVelocity = 10;
    public PlayerAnimationController playerAnim;

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        if (Mathf.Abs(horizontal) > 0)
        {
            // Movimento
            transform.position += transform.right * horizontal * (Time.deltaTime * playerVelocity);

            // Flip
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Sign(horizontal) * Mathf.Abs(scale.x);
            transform.localScale = scale;

            // Ativa animação
            playerAnim.SetIsWalking(true);
        }
        else
        {
            playerAnim.SetIsWalking(false);
        }
    }
}
