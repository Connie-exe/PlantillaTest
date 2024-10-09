using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara_Controller : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        player = GameObject.Find("Jugador"); //asignamos el gameobject Jugador a la variable Player (aunque como nuestra variable es pública lo podemos hacer desde Unity)
    }

    // Update is called once per frame
    void Update()
    {
        //al final de cada frame modificamos la posición del objeto que tiene asignado este script (en este casola cámara), modificamos sus variables x, y, z en relación a la posición del player.
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 10); //restamos 10 a la posición en z para que la cámara no esté justo sobre el player si no un poco más alejada así podemos ver qué sucede en la escena.
    }
}
