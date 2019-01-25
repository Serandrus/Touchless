using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This class defines the condition to win the game.
/// </summary>
public class WinObject : MonoBehaviour
{
    public Player player;
    bool active;

    //Searchs the player.
    void Awake()
    {
        player = FindObjectOfType<Player>().GetComponent<Player>();
    }

    //Stop the game when the player collides with it.
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            active = !active;
            Time.timeScale = (active) ? 0 : 1f;
        }
    }
}
