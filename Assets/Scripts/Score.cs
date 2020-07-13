using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player;
    public Text score;
    public AudioSource increaseAudio;

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1)
        {
            score.text = player.position.z.ToString("0");
            increaseAudio.pitch += 0.000035f;
        }
    }
}
