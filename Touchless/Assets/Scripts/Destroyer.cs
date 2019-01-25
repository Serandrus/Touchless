using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Avoid the possibility of spawn a closed romm inside the initial room.
/// </summary>
public class Destroyer : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ClosedRoom"))
        {
            Destroy(other.gameObject);
        } 
    }
}
