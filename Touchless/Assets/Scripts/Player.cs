using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This class sets all the components of the player.
/// </summary>
public class Player : MonoBehaviour
{
    float speed;
    public Vector2 position;
    public GameObject gameOverText;
    public GameObject youWinText;
    private Rigidbody rb;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        gameOverText.SetActive(false);
        youWinText.SetActive(false);
        speed = 200f;

        rb = GetComponent<Rigidbody>();

        position.x = 0;
        position.y = 0;
    }

    void Update ()
    {
        float inputX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float inputY = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        rb.velocity = new Vector3(inputX, inputY, 0);
	}
    
    //Sets the wining and losing conditions.
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            gameOverText.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }

        if (collision.gameObject.GetComponent<WinObject>())
        {
            youWinText.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
