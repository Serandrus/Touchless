using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLoader : MonoBehaviour
{

	void Start ()
    {
        StartCoroutine("CountDown");
	}
	
	private IEnumerator CountDown()
    {
        yield return new WaitForSeconds(7);
        SceneManager.LoadScene("Menu");
    }
}
