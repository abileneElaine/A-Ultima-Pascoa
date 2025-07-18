using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public Animator animator;

    public void SetIsWalking(bool isWalking)
    {
        animator.SetBool("isWalking", isWalking);
    }
}
