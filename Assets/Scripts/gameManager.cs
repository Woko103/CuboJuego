using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public Text score;
    bool gameHasEnded = false;

    public void endGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Invoke("showCredits", 1f);
        }
    }

    void showCredits ()
    {
        int actualScore = int.Parse(score.text);
        PlayerPrefs.SetInt("score", actualScore);
        if (actualScore > PlayerPrefs.GetInt("highScore", 0))
        {
            PlayerPrefs.SetInt("highScore", actualScore);
        }
        Debug.Log(PlayerPrefs.GetInt("highScore", 0));
        SceneManager.LoadScene("credits");
    }
}
