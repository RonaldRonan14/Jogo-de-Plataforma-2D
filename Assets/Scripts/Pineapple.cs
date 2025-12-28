using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(CircleCollider2D))]
public class Pineapple : MonoBehaviour
{
    private SpriteRenderer sr;
    private CircleCollider2D circle;

    public GameObject collected;
    public int score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            sr.enabled = false;
            circle.enabled = false;
            collected.SetActive(true);
            AudioManager.instance.PlaySFX(AudioManager.instance.collected);
            GameController.instance.AddScore(score);

            Destroy(gameObject, 0.25f);
        }
    }
}
