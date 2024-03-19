using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField] float ballSpeed;
    [SerializeField] GameObject ball, leftBarrier, rightBarrier, qPaddle;
    [SerializeField] int score1, score2;

    void Start() {
        SpawnBall();
    }

    void Update() {
        if (ball.transform.position.x > rightBarrier.transform.position.x) {
            score1++;
            GameObject.Find("Score1").GetComponent<TMP_Text>().text = score1.ToString();
            SpawnBall();
        } else if (ball.transform.position.x < leftBarrier.transform.position.x) {
            score2++;
            GameObject.Find("Score2").GetComponent<TMP_Text>().text = score2.ToString();
            SpawnBall();
        }
    }

    private void SpawnBall() {
        qPaddle.GetComponent<Qlearning>().behindPaddle = false;
        ball.transform.position = new Vector2(10.197f, 6.093f);
        switch (Random.Range(0, 4)) {
            case 0:
                ball.GetComponent<Rigidbody2D>().velocity = new Vector2(1, 1) * ballSpeed;
                break;
            case 1:
                ball.GetComponent<Rigidbody2D>().velocity = new Vector2(1, -1) * ballSpeed;
                break;
            case 2:
                ball.GetComponent<Rigidbody2D>().velocity = new Vector2(-1, 1) * ballSpeed;
                break;
            case 3:
                ball.GetComponent<Rigidbody2D>().velocity = new Vector2(-1, -1) * ballSpeed;
                break;
        }
    }

    //void Update() {
    //    if (ball.transform.position.x > rightBarrier.transform.position.x) {
    //        score1++;
    //        GameObject.Find("Score1").GetComponent<TMP_Text>().text = score1.ToString();
    //        SpawnBall();
    //    } else if (ball.transform.position.x < leftBarrier.transform.position.x) {
    //        score2++;
    //        GameObject.Find("Score2").GetComponent<TMP_Text>().text = score2.ToString();
    //        SpawnBall();
    //    }
    //}

    //void FixedUpdate() {
    //    ball.transform.position = new Vector2(ball.transform.position.x + 1, ball.transform.position.y +1);   
    //}

    //private void SpawnBall() {
    //    ball.transform.position = Vector2.zero;
    //    switch (Random.Range(0, 4)) {
    //        case 0:
    //            ball.transform.position = new Vector2(1, 1);
    //            break;
    //        case 1:
    //            ball.transform.position = new Vector2(1, -1);
    //            break;
    //        case 2:
    //            ball.transform.position = new Vector2(-1, 1);
    //            break;
    //        case 3:
    //            ball.transform.position = new Vector2(-1, -1);
    //            break;
    //    }
    //}
}
