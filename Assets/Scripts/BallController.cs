using UnityEngine;

public class BallController : MonoBehaviour {
    private Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.gameObject.CompareTag("Paddle")) 
            rb.velocity *= 1.5f; 
    }
}
