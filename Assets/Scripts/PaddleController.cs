using UnityEngine;

public class PaddleController : MonoBehaviour {

    [SerializeField] float speed;

    void Start() {
        
    }

    void Update() {
        float motion = Input.GetAxisRaw("Vertical");
        if (motion > 0) GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
        else if (motion < 0) GetComponent<Rigidbody2D>().velocity = Vector2.down * speed;
        else GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    private void FixedUpdate() {
        
    }
}
