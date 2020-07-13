using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 400f;
    private bool isGrounded;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.timeScale == 1)
        {
            forwardForce += 0.4f;
            rb.AddForce(0,0,forwardForce*Time.deltaTime);

            float touchPosition = -1f;
            //Mobile controls
            if (Input.touchCount > 0)
            {
                touchPosition = Input.GetTouch(0).position.x;
            }

            //Right move
            if (Input.GetKey("d") || touchPosition > 399)
            {
                if (isGrounded)
                    rb.AddForce(70*Time.deltaTime,0,0,ForceMode.VelocityChange);
                else
                    rb.AddForce(10*Time.deltaTime,0,0,ForceMode.VelocityChange);
            }
            //Left move
            if (Input.GetKey("a") || (touchPosition < 201 && touchPosition > -1))
            {
                if (isGrounded)
                    rb.AddForce(-70*Time.deltaTime,0,0,ForceMode.VelocityChange);
                else
                    rb.AddForce(-10*Time.deltaTime,0,0,ForceMode.VelocityChange);
            }
            //Jump
            if (isGrounded && (Input.GetKey("space") || (touchPosition > 201 && touchPosition < 399)))
            {
                rb.AddForce(0,300*Time.deltaTime,0,ForceMode.VelocityChange);
            }
            //Falling
            if (rb.position.y < 0.8f)
            {
                FindObjectOfType<gameManager>().endGame();
            }
        }
    }

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}