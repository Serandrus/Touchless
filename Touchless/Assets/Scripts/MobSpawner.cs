using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This class spawns all the enemys in the game.
/// </summary>
public class MobSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    int randomSpawn;

    // Use this for initialization
    void Awake ()
    {
        randomSpawn = Random.Range(1, 7);

        for (int i = 0; i < randomSpawn; i++)
        {
            GameObject go = Instantiate(enemyPrefab);
            Vector2 pos = new Vector2(Random.Range(-3, 4), Random.Range(-3, 4));
            go.transform.SetParent(gameObject.transform);
            go.transform.localPosition = pos;
        }
	}
}
