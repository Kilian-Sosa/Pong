using UnityEngine;

public class PaddleController : MonoBehaviour {

    void Start() {
        
    }

    void Update() {
        float motion = Input.GetAxisRaw("Vertical");
        if (motion > 0) GetComponent<Rigidbody2D>().velocity = Vector2.up;
        else if (motion < 0) GetComponent<Rigidbody2D>().velocity = Vector2.down;
        else GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    private void FixedUpdate() {
        
    }
}
