using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField] float ballSpeed;
    [SerializeField] GameObject ball, leftBarrier, rightBarrier;
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
        ball.transform.position = Vector2.zero;
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
}
