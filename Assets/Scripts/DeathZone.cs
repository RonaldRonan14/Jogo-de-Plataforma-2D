using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public Transform respawnPoint;

    private GameObject playerRef;
    private SpriteRenderer playerSprite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerRef = collision.gameObject;
            playerSprite = playerRef.GetComponent<SpriteRenderer>();

            AudioManager.instance.PlaySFX(AudioManager.instance.danger);
            GameController.instance.LoseLife();

            if (playerSprite != null) playerSprite.enabled = false;

            Invoke(nameof(RestoresPosition), 1f);
        }
    }

    private void RestoresPosition()
    {
        playerRef.transform.position = respawnPoint.position;
        if (playerRef.TryGetComponent<Rigidbody2D>(out var rb))
        {
            rb.linearVelocity = Vector2.zero;
        }
        if (playerSprite != null) playerSprite.enabled = true;
    }
}
