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

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            RotatePaddle(1f);
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            RotatePaddle(-1f);
        else if (GetComponent<Rigidbody2D>().rotation > 0 && GetComponent<Rigidbody2D>().rotation % 360 < 10 || 
                GetComponent<Rigidbody2D>().rotation < 0 && GetComponent<Rigidbody2D>().rotation % 360 > -10) {
            GetComponent<Transform>().rotation = Quaternion.identity;
            GetComponent<Rigidbody2D>().freezeRotation = true;
            GetComponent<Rigidbody2D>().angularVelocity = 0f;
        }
    }

    void RotatePaddle(float direction) {
        GetComponent<Rigidbody2D>().freezeRotation = false;
        GetComponent<Rigidbody2D>().rotation = direction * 12f;
        GetComponent<Rigidbody2D>().AddTorque(direction, ForceMode2D.Impulse);
    }
}
