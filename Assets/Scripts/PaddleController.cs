using UnityEngine;

public class PaddleController : MonoBehaviour {

    [SerializeField] float paddleSpeed; // For controlling the movement vel. of the paddle

    void Start() {
        
    }

    void Update() {
        float motion = Input.GetAxisRaw("Vertical");
        if (motion > 0) GetComponent<Rigidbody2D>().velocity = Vector2.up * paddleSpeed;
        else if (motion < 0) GetComponent<Rigidbody2D>().velocity = Vector2.down * paddleSpeed;
        else GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    private void FixedUpdate() {
        
    }
}
