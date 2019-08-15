using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void shakeScreen()
    {
        animator.SetTrigger("Shake");
    }

    public void shakeScreenHard()
    {
        animator.SetTrigger("HardShake");
    }
}
