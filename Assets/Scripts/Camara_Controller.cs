using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara_Controller : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        player = GameObject.Find("Jugador"); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 10);
    }
}
