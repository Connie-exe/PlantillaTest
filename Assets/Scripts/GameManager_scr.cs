using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //permite manejar las escenas de Unity desde el código

public class GameManager_scr : MonoBehaviour
{

    void Start()
    {
        
    }
    void Update()
    {
        //ReloadScene();
        ReloadScene();
    }

    //public static void ReloadScene()
    //{
    //    if (Input.GetKey(KeyCode.R)) //al presionar la tecla R
    //    {
    //        SceneManager.LoadScene(0); //se recarga la escena
    //    }
    //}

    void ReloadScene()
    {
        if(Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }

}
