using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed;
    public Vector2 position;
    public GameObject gameOverText;
    public GameObject youWinText;
    private Rigidbody rb;

    void Start()
    {
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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            gameOverText.SetActive(true);
        }

        if (collision.gameObject.GetComponent<WinObject>())
        {
            youWinText.SetActive(true);
        }
    }
}
