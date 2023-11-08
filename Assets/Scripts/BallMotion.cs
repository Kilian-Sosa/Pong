using UnityEngine;

public class BallMovement : MonoBehaviour {

    [SerializeField] float speed;
    [SerializeField] GameObject leftPaddle, rightPaddle;

    void Start() {
        Spawn();
    }

    void Update() {
        if (transform.position.x > rightPaddle.transform.position.x) 
            Spawn();
        else if (transform.position.x < leftPaddle.transform.position.x) 
            Spawn();
    }

    private void Spawn() {
        transform.position = Vector2.zero;
        switch (Random.Range(0, 4)) {
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
}
