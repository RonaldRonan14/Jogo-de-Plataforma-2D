using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Heart : MonoBehaviour
{
    private Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void LostHeart()
    {
        anim.SetBool("alive", false);
    }
}
