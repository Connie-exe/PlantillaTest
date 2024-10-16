﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //permite manejar las escenas de Unity desde el código


public class Controller_Player : MonoBehaviour
{
    public float speed = 5;

    private Rigidbody rb;

    public GameObject projectile;
    public GameObject doubleProjectile;
    public GameObject missileProjectile;
    public GameObject laserProjectile;
    public GameObject option;
    public int powerUpCount = 0;

    internal bool doubleShoot;
    internal bool missiles;
    internal float missileCount;
    internal float shootingCount = 0;
    internal bool forceField;
    internal bool laserOn;

    public static bool lastKeyUp;

    public delegate void Shooting();
    public event Shooting OnShooting;

    private Renderer render;

    internal GameObject laser;

    //private List<Controller_Option> options;

    public static Controller_Player _Player;

    // Variable para consignas
    public GameObject PowerUp;
    public Transform enemigo;
    private void Awake()
    {
        if (_Player == null)
        {
            _Player = GameObject.FindObjectOfType<Controller_Player>();
            if (_Player == null)
            {
                GameObject container = new GameObject("Player");
                _Player = container.AddComponent<Controller_Player>();
            }
            //Debug.Log("Player==null");

           //DontDestroyOnLoad(_Player);
        }
        else
        {
            //Debug.Log("Player=!null");
            //this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        render = GetComponent<Renderer>();
        powerUpCount = 0;
        doubleShoot = false;
        missiles = false;
        laserOn = false;
        forceField = false;
        //options = new List<Controller_Option>();
    }

    private void Update()
    {
        //CheckForceField();
        ActionInput();
    }

    //private void CheckForceField()
    //{
    //    if (forceField)
    //    {
    //        render.material.color = Color.blue;
    //    }
    //    else
    //    {
    //        render.material.color = Color.red;
    //    }
    //}

    public virtual void FixedUpdate()
    {
        Movement();
    }

    public virtual void ActionInput()
    {
        missileCount -= Time.deltaTime;
        shootingCount -= Time.deltaTime;
        float spawnDist = 1; //la distancia del spawneo sirve para que la bala no salga justo del centro del juegador
        if (Input.GetKey(KeyCode.Space) && shootingCount < 0) //cambiamos el keycode para que se pueda dispara con la barra espaciadora
        {
            if (OnShooting != null)
            {
                OnShooting();
            }

            //Instantiate(projectile, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
            Instantiate(projectile, transform.position + spawnDist * transform.forward, transform.rotation); // ahora las balas se instancian en el "adelante" del player

            shootingCount = 0.1f;
        }
    }


    private void Movement()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(speed * inputX, speed * inputY);
        rb.velocity = movement;
        if (Input.GetKey(KeyCode.W))
        {
            lastKeyUp = true;
        }
        else
        if (Input.GetKey(KeyCode.S))
        {
            lastKeyUp = false;
        }

        if(movement != Vector3.zero) //chequeamos si el jugador se está moviendo verificando si el movimiento del vector de transform no es 0
        {
            transform.forward = movement; //si es true, programamos que la dirección "adelante" sea conforme a nuestro movimiento
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "PowerUp") //si colisionamos con un objeto de nombre "PowerUp"
        {
            speed += 5; //sumamos 5 a la variable speed
            //Destroy(collision.gameObject); // se destruye el objeto con el que colisionamos
            collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.name == "Enemigo") //si colisionamos con un objeto de nombre "Enemigo"
        {
            //Destroy(gameObject);
            SceneManager.LoadScene(0); // se recarga la escena
        }
    }


}
