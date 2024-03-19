using UnityEngine;

public class BallController : MonoBehaviour {
    private Rigidbody2D rb;
    private float velocityIncrease = 0;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.gameObject.CompareTag("Paddle") && velocityIncrease < 3) {
            velocityIncrease++;
            rb.velocity *= 1.5f;
        }
    }
}
