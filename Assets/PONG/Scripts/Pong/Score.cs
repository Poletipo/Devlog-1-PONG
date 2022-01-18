using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour {

    public Ball ball;
    int[] scores = { 0, 0 };
    public Pallets[] pallets;
    public TextMeshProUGUI[] textScores;
    public TextMeshProUGUI WinScreen;

    bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        ball.OnBallScoring += OnScoring;

        for (int i = 0; i < pallets.Length; i++) {
            pallets[i].playerIndex = PassedData.playerIndexes[i];
        }
    }

    private void OnScoring(int goalIndex)
    {
        scores[goalIndex]++;
        textScores[goalIndex].text = scores[goalIndex].ToString();


        if (scores[goalIndex] >= 10) {
            WinScreen.gameObject.SetActive(true);
            WinScreen.text = "Player " + (goalIndex + 1).ToString() + " Won";
            gameOver = true;
            ball.gameObject.SetActive(false);
        }
        else {
            ball.StartCoroutine(ball.ResetBall());
        }
    }

    private void Update()
    {
        if (gameOver && Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene(0);
        }
    }


}
