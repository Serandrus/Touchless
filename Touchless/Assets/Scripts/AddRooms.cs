using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This class is going to add rooms to the array.
/// </summary>
public class AddRooms : MonoBehaviour
{
    private RoomTemplates templates;

    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        templates.rooms.Add(this.gameObject);
    }

}
