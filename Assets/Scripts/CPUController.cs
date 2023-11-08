using UnityEngine;

public class CPU : MonoBehaviour {

    [SerializeField] GameObject ball;
    [SerializeField] float speed;

    void Start() {
        
    }

    void Update() {

    }

    private void FixedUpdate() {
        if (transform.position.y < ball.transform.position.y) 
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * speed);
        else if (transform.position.y > ball.transform.position.y) 
            GetComponent<Rigidbody2D>().AddForce(Vector2.down * speed);
        else GetComponent<Rigidbody2D>().AddForce(Vector2.zero);
    }
}