using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This class gives all the information of the enemys.
/// </summary>
public class Enemy : MonoBehaviour, IEnemyBehaviour
{
    public Player player;
    public Parameters info;
    bool active;

    private void Awake()
    {
        player = FindObjectOfType<Player>().GetComponent<Player>();
        info.type = Random.Range(1, 5);
        info.speed = 5f;
        StartCoroutine(Behaviour());
    }

    void Update()
    {
        EnemyMovement();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            active = !active;
            Time.timeScale = (active) ? 0 : 1f;
        }
    }

    //Choose one of those types of actions.
    void StartMoving()
    {
        switch (info.behavior)
        {
            case EnemyBehavior.idle:
                info.type = 5;
                StartCoroutine(Behaviour());
                break;
            case EnemyBehavior.moving:
                info.type = Random.Range(1, 6);
                StartCoroutine(Behaviour());
                break;
        }
    }

    //Sets the enemy movement.
    public void EnemyMovement()
    {

        switch (info.type)
        {
            case 1:
                transform.position += transform.up * info.speed * Time.deltaTime;
                break;
            case 2:
                transform.position -= transform.up * info.speed * Time.deltaTime;
                break;
            case 3:
                transform.position += transform.right * info.speed * Time.deltaTime;
                break;
            case 4:
                transform.position -= transform.right * info.speed * Time.deltaTime;
                break;
            case 5:
                transform.position += new Vector3(0, 0, 0);
                break;
        }

        if (info.type == 1 && transform.localPosition.y >= 3)
        {
            info.type = Random.Range(1, 5);
        }
        else
        {
            if (info.type == 2 && transform.localPosition.y <= -3)
            {
                info.type = Random.Range(1, 5);
            }
            else
            {
                if (info.type == 3 && transform.localPosition.x >= 3)
                {
                    info.type = Random.Range(1, 5);
                }
                else
                {
                    if (info.type == 4 && transform.localPosition.x <= -3)
                    {
                        info.type = Random.Range(1, 5);
                    }
                }
            }
        }
    }

    //Calls the start moving method every two seconds to change the enemy behaviour.
    public IEnumerator Behaviour()
    {
        yield return new WaitForSeconds(2);

        while (true)
        {
            info.behavior = (EnemyBehavior)Random.Range(0, 2);
            StartMoving();
            yield return new WaitForSeconds(2);
        }
    }
}

public interface IEnemyBehaviour
{
    void EnemyMovement();
}

//Gives parameters to our enemys.
public struct Parameters
{
    public EnemyBehavior behavior;
    public int type;
    public float speed;
}

public enum EnemyBehavior
{
    idle,
    moving
}
