using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinObject : MonoBehaviour
{

    public Player player;
    bool active;

    void Awake()
    {
        player = FindObjectOfType<Player>().GetComponent<Player>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            active = !active;
            Time.timeScale = (active) ? 0 : 1f;
            //player.GetComponent<Player>().enabled = false;
            //Destroy(collision.gameObject);
        }
    }
}
