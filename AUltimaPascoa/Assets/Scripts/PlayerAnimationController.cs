using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Ativa ou desativa a animação de andar
    public void SetIsWalking(bool isWalking)
    {
        animator.SetBool("isWalking", isWalking);
    }

    // Ativa ou desativa a animação de pulo
    public void SetIsJumping(bool isJumping)
    {
        animator.SetBool("isJumping", isJumping);
    }
}
