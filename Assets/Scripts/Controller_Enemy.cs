using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //permite usar elementos de UI como el objeto Text

public class Controller_Enemy : MonoBehaviour
{
    private GameObject Player;
	private Transform target;
	public float minDist;
    public float speed;
    private Rigidbody rb_enemy;

    //Variables para Consignas
    public Text txt_puntos;
    public int puntos;
    void Start()
	{
        txt_puntos.text = "Puntos: " + puntos; //se asigna desde el inicio lo que mostrará el texto de puntos

        // Si no asignamos el target en Unity, el código lo busca
        if (Player == null)
        {

            if (GameObject.FindWithTag("Player") != null)
            {
                target = GameObject.FindWithTag("Player").GetComponent<Transform>();
            }
        }
    }

	void Update()
	{
		// Si no existe el target que no ejecute las líneas siguientes. Así ahorramos errores.
		if (target == null)
			return;

		// Mira al target
		transform.LookAt(target);

		// Mide la distancia entre este objeto (que tiene asignado este script) y el target (posición del Player)
		float distance = Vector3.Distance(transform.position, target.position);

		// Si el target está más lejos que la distancia mínima el enemigo lo persigue
		if (distance > minDist)
			transform.position += transform.forward * speed * Time.deltaTime; //se modifica la posición del enemigo con respecto a la velocidad que le asignamos y se mueve hacia adelante
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "proyectil(Clone)")
        {
            puntos += 10;
            txt_puntos.text = "Puntos: " + puntos;
            Destroy(gameObject);
        }
    }


}
