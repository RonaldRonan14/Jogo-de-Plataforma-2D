using UnityEngine;

[RequireComponent(typeof(TargetJoint2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]
public class FallingPlatform : MonoBehaviour
{
    public float fallingTime;

    private TargetJoint2D target;
    private Vector2 startPosition;
    private Quaternion startRotation;
    private SpriteRenderer sr;
    private Collider2D col;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = GetComponent<TargetJoint2D>();
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
        
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke(nameof(Falling), fallingTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Danger"))
        {
            HidePlatform();
        }
    }

    void Falling()
    {
        target.enabled = false;
    }

    void HidePlatform()
    {
        sr.enabled = false;
        col.enabled = false;
        target.enabled = false;
    }

    public void ResetPlatform()
    {
        CancelInvoke();
        sr.enabled = true;
        col.enabled = true;
        target.enabled = true;
        
        transform.SetPositionAndRotation(startPosition, startRotation);

        if(TryGetComponent<Rigidbody2D>(out var rb)) {
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0;
        }
    }
}
