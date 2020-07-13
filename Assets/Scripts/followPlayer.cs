using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    private bool thirdPerson = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("c"))
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
        if (thirdPerson) //Tercera persona
            transform.position = player.position + offset;
        else //Primera persona
            transform.position = player.position;
    }
}
