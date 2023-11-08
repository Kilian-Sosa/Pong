using UnityEngine;

public class BallMovement : MonoBehaviour {

    [SerializeField] float speed;

    void Start() {
        float direction = Random.Range(0, 4);
        switch(direction) {
            case 0:
                GetComponent<Rigidbody2D>().velocity = new Vector2(1, 1) * speed;
                break;
            case 1:
                GetComponent<Rigidbody2D>().velocity = new Vector2(1, -1) * speed;
                break;
            case 2:
                GetComponent<Rigidbody2D>().velocity = new Vector2(-1, 1) * speed;
                break;
            case 3:
                GetComponent<Rigidbody2D>().velocity = new Vector2(-1, -1) * speed;
                break;
        }
    }

    void Update() {
        
    }
}
