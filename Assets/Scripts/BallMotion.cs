using TMPro;
using UnityEngine;

public class BallMovement : MonoBehaviour {

    [SerializeField] float speed;
    [SerializeField] GameObject leftPaddle, rightPaddle;
    [SerializeField] int score1, score2;

    void Start() {
        Spawn();
    }

    void Update() {
        if (transform.position.x > rightPaddle.transform.position.x) {
            score1++;
            GameObject.Find("Score1").GetComponent<TMP_Text>().text = score1.ToString();
            Spawn();
        } 
        else if (transform.position.x < leftPaddle.transform.position.x) {
            score2++;
            GameObject.Find("Score2").GetComponent<TMP_Text>().text = score2.ToString();
            Spawn();
        } 
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
