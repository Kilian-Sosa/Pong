using UnityEngine;
using System.IO;
using TMPro;
using System;
using System.Globalization;

public class Qlearning : MonoBehaviour {

    int paddlePositions = 8;
    int ballPositionsX = 17;
    int ballPositionsY = 8;
    int actionsNum = 3;
    double[,,,] QTable; 

    float learningRate = 0.5f;
    float discountFactor = 0.1f;
    float explorationRate = 0.1f;

    public float paddleVelocity;
    Vector2 ballVelocity;

    int[] state = new int[3];
    int[] oldState = new int[3];
    int action = 0;

    GameObject ball;
    Transform paddle;

    float minY = 2.5f;
    float maxY = 9f;
    public TextMeshProUGUI scoreText;

    public bool behindPaddle;

    void Start() {
        //Time.timeScale = 30;
        ball = GameObject.Find("Ball");
        QTable = new double[paddlePositions, ballPositionsX, ballPositionsY, actionsNum];
        paddle = transform;
        behindPaddle = false;
        LoadQTableFromFile();
    }

    void Update() {
        ball = GameObject.Find("Ball");
        ballVelocity = ball.GetComponent<Rigidbody2D>().velocity;

        Vector2 ballPosition = ball.transform.position;
        Vector2 paddlePosition = paddle.position;

        if (paddleVelocity == 0 || ballVelocity.x == 0 || ballVelocity.y == 0) return;
        state = new int[3];
        state[0] = (int)(paddlePosition.y) - 2;
        state[1] = (int)(ballPosition.x) - 2;
        state[2] = (int)(ballPosition.y) - 2;

        Array.Copy(state, oldState, 3);
        action = EpsilonGreedy(state);

        MovePaddle(action);

        if (ballPosition.x < paddlePosition.x && !behindPaddle) {
            UpdateQTable(oldState, action, state, -1f);
            behindPaddle = true;
        }
    }

    int EpsilonGreedy(int[] state) {
        if (GameManager.instance.score1 != 0 && GameManager.instance.score1 % 100 == 0) {
            explorationRate *= explorationRate;
            print(explorationRate);
        }
        if (UnityEngine.Random.Range(0f, 1f) <= explorationRate) return UnityEngine.Random.Range(0, 3);
        else return Array.IndexOf(GetActionValues(state), GetMaxQValue(state));
    }

    void MovePaddle(int action) {
        switch (action) {
            case 0:
                break;
            case 1:
                float newYPosRight = Mathf.Clamp(paddle.transform.position.y + paddleVelocity * Time.deltaTime, minY, maxY);
                paddle.position = new Vector2(paddle.position.x, newYPosRight);
                break;
            case 2:
                float newYPosLeft = Mathf.Clamp(paddle.transform.position.y - paddleVelocity * Time.deltaTime, minY, maxY);
                paddle.position = new Vector2(paddle.position.x, newYPosLeft);
                break;
        }
    }

    double[] GetActionValues(int[] state) {
        int paddlePos = state[0];
        int ballPosX = state[1];
        int ballPosY = state[2];

        double[] actionValues = new double[QTable.GetLength(3)];
        for (int i = 0; i < actionValues.Length; i++) actionValues[i] = 0;
        for (int i = 0; i < actionValues.Length; i++) {
            try {
                actionValues[i] = QTable[paddlePos, ballPosX, ballPosY, i];
            } catch (IndexOutOfRangeException) {
                Debug.LogWarning($"IndexOutOfRange: {paddlePos}, {ballPosX}, {ballPosY}");
            }
        }
        return actionValues;
    }

    double GetMaxQValue(int[] state) {
        double[] actionValues = GetActionValues(state);
        double maxQValue = double.MinValue;

        foreach (double qValue in actionValues) if (qValue > maxQValue) maxQValue = qValue;
        return maxQValue;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ball")) {
            UpdateQTable(oldState, action, state, 100f);
            scoreText.text = $"{++GameManager.instance.score1}";
        }
    }

    void UpdateQTable(int[] oldState, int actionTaken, int[] newState, double reward) {
        double actualQValue = 0;
        try {
            actualQValue = QTable[oldState[0], oldState[1], oldState[2], actionTaken];
        } catch (IndexOutOfRangeException) {
            Debug.LogWarning($"IndexOutOfRange: {oldState[0]}, {oldState[1]}, {oldState[2]}");
            return;
        }

        double futureMaxQValue = (double)(reward + discountFactor * GetMaxQValue(newState));

        double newValue = actualQValue + learningRate * (futureMaxQValue - actualQValue);
        QTable[oldState[0], oldState[1], oldState[2], actionTaken] = newValue;
        print($"Updated QTable value at [{oldState[0]}, {oldState[1]}, {oldState[2]}, {actionTaken}]: {actualQValue} - {newValue}");
    }

    void LoadQTableFromFile() {
        string filePath = Application.persistentDataPath + "/QTable.csv";

        if (File.Exists(filePath)) {
            using (StreamReader reader = new StreamReader(filePath)) {
                for (int i = 0; i < paddlePositions; i++)
                    for (int j = 0; j < ballPositionsX; j++)
                        for (int k = 0; k < ballPositionsY; k++) {
                            string line = reader.ReadLine();
                            if (!string.IsNullOrEmpty(line)) {
                                string[] values = line.Split(',');
                                for (int l = 0; l < actionsNum; l++) {
                                    string formattedValue = values[l].Replace('.', ',');
                                    if (float.TryParse(formattedValue, out float value)) {
                                        QTable[i, j, k, l] = value;
                                    } else {
                                        Debug.LogWarning("Invalid value in QTable file.");
                                    }
                                }
                            } else {
                                Debug.LogWarning("Empty line found in QTable file.");
                                break;
                            }
                        }
            }
            Debug.Log("QTable loaded from: " + filePath);
        } else {
            Debug.LogWarning("No QTable file found. Creating new QTable.");
            InitializeQTable();
        }
    }

    void InitializeQTable() {
        QTable = new double[paddlePositions, ballPositionsX, ballPositionsY, actionsNum];
        for (int i = 0; i < paddlePositions; i++)
            for (int j = 0; j < ballPositionsX; j++)
                for (int k = 0; k < ballPositionsY; k++)
                    for (int l = 0; l < actionsNum; l++)
                        QTable[i, j, k, l] = UnityEngine.Random.Range(0, 10);
    }

    void OnApplicationQuit() {
        SaveQTableToFile();
    }

    void SaveQTableToFile() {
        string filePath = Application.persistentDataPath + "/QTable.csv";

        using (StreamWriter writer = new StreamWriter(filePath)) {
            for (int i = 0; i < paddlePositions; i++)
                for (int j = 0; j < ballPositionsX; j++)
                    for (int k = 0; k < ballPositionsY; k++) {
                        for (int l = 0; l < actionsNum; l++) {
                            double value = QTable[i, j, k, l];
                            string formattedValue = value.ToString(CultureInfo.InvariantCulture);
                            writer.Write(formattedValue);
                            if (l < actionsNum - 1) writer.Write(",");
                        }
                        writer.WriteLine();
                    }
        }
        Debug.Log("QTable saved to: " + filePath);
        Debug.Log($"Exploration Rate: {explorationRate}");
    }
}