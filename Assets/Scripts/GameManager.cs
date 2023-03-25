using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {

    public Player player;

    public TMP_Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    private int score;

    private void Awake() {

        Application.targetFrameRate = 60;
        Pause();
    }

    public void Play() {
        score = 0;
        scoreText.text = score.ToString();
        playButton.SetActive(false);
        gameOver.SetActive(false);
        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();
        for (int i = 0; i < pipes.Length; i++) {
            Destroy(pipes[i].gameObject);
        }
    }
    public void Pause() {
        // freezes the game
        Time.timeScale = 0f;
        // since in Update function we multiply movements (position) by Time.deltaTime
        // by setting timeScale to 0, the position increments will be zero
        // transform.position += Vector3.left * speed * Time.deltaTime;

        player.enabled = false;
    }
    public void GameOver() {
        Debug.Log("Game over");
        gameOver.SetActive(true);
        playButton.SetActive(true);
        Pause();
    }
    public void IncreaseScore() {
        score++;
        Debug.Log(score);
        scoreText.text = score.ToString();
    }

}
