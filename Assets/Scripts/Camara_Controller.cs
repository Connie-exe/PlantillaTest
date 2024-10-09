using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara_Controller : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        player = GameObject.Find("Jugador"); //asignamos el gameobject Jugador a la variable Player (aunque como nuestra variable es p�blica lo podemos hacer desde Unity)
    }

    // Update is called once per frame
    void Update()
    {
        //al final de cada frame modificamos la posici�n del objeto que tiene asignado este script (en este casola c�mara), modificamos sus variables x, y, z en relaci�n a la posici�n del player.
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 10); //restamos 10 a la posici�n en z para que la c�mara no est� justo sobre el player si no un poco m�s alejada as� podemos ver qu� sucede en la escena.
    }
}
