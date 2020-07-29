using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menu : MonoBehaviour
{
    public Text scoreText;
    public Text isHighScore;

    private void Start()
    {
        scoreText.text = PlayerPrefs.GetInt("score", 0).ToString();

        if (PlayerPrefs.GetInt("score", 0) == PlayerPrefs.GetInt("highScore", 0))
        {
            isHighScore.text = "New Highscore!";
            isHighScore.color = Color.magenta;
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void StartTwoGame()
    {
        SceneManager.LoadScene("GameTwo");
    }
}