using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    private bool thirdPerson = true;

    // Update is called once per frame
    void Update()
    {
        bool twoMode = FindObjectOfType<gameManager>().twoMode;

        if (Input.GetKeyDown("c") && !twoMode)
        {
            if (thirdPerson)
            {
                thirdPerson = false;
            }
            else
            {
                thirdPerson = true;
            }
        }

        if (thirdPerson)
            transform.position = player.position + offset;
        else //First person
            transform.position = player.position;
    }
}
