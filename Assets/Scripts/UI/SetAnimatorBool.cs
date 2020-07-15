using UnityEngine;

public class SetAnimatorBool : MonoBehaviour
{
    public Animator animator;
    [SerializeField] string boolToSet = "game over";
    private int animatorBoolHashed;

    private void Start()
    {
        animatorBoolHashed = Animator.StringToHash(boolToSet);
    }

    public void SetBool(bool value)
    {
        animator.SetBool(animatorBoolHashed, value);
    }
}