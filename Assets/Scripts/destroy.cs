using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    public int timer = 60;
    void FixedUpdate()
    {
        --timer;

        if (timer == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
