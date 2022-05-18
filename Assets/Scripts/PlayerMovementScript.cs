using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovementScript : MonoBehaviour
{
    Rigidbody rb;
    Animator myAnim;
    public float forceMagnitude;
    public float speed;
    public float rotateSpeed;
    public static Vector3 lastCheckpointPos = new Vector3(1, 0, 10);

    private float playerSpeed;
    private bool isGameOver;

    void playerMovementHandler ()
    {
        // If the player is not falling then run
        if (!myAnim.GetBool("isFalling"))
        {
            // Run forward on W & show running animation
            if (Input.GetKey(KeyCode.W))
            {
                // Add force in forward direction
                rb.AddForce(transform.forward * forceMagnitude * Time.deltaTime, ForceMode.VelocityChange);

                // Clamp velocity
                float xCap = playerSpeed * Mathf.Sin(Mathf.Abs(transform.rotation.y));
                float zCap = playerSpeed * Mathf.Cos(Mathf.Abs(transform.rotation.y));

                rb.velocity = new Vector3(
                    Mathf.Clamp(rb.velocity.x, -xCap, xCap),
                    rb.velocity.y,
                    Mathf.Clamp(rb.velocity.z, -zCap, zCap)
                );

                // Set running animation
                myAnim.SetBool("isRunning", true);
            }
            // Show breathing animation
            else
            {
                // Not pressing W -> Not Running
                myAnim.SetBool("isRunning", false);
            }
        }
    }

    void playerRotationHandler ()
    {
        // Rotate right on D
        if (Input.GetKey(KeyCode.D))
        {
            // Rotate in clockwise direction 
            transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
        }
        // Rotate left on A
        if (Input.GetKey(KeyCode.A))
        {
            // Rotate in anti-clockwise direction
            transform.Rotate(Vector3.up, -rotateSpeed * Time.deltaTime);
        }
    }

    private void Awake()
    {
        Debug.Log(lastCheckpointPos);
        isGameOver = false;
        transform.position = lastCheckpointPos;
    }

    void Start()
    {
        playerSpeed = speed;
        rb = GetComponent<Rigidbody>();
        myAnim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        // If the game is not over, move player
        if (isGameOver == false)
        {
            // Handle player's movements
            playerMovementHandler();

            // Handle player's rotation
            playerRotationHandler();
        }

        if ( myAnim.GetBool("isFalling") )
        {
            myAnim.SetBool("isFalling", true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ( collision.gameObject.CompareTag("conveyor") )
        {
            playerSpeed = speed / 3;
            myAnim.SetBool("isFalling", false);
        }
        else if ( collision.gameObject.CompareTag("obstacle") )
        {
            myAnim.SetBool("isFalling", true);
            rb.velocity = new Vector3(0, 0, 0);
        }
        else if (collision.gameObject.CompareTag("Respawn") )
        {
            isGameOver = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            playerSpeed = speed;
            myAnim.SetBool("isFalling", false);
        }
    }


}
