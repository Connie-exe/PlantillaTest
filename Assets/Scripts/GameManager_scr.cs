using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //permite manejar las escenas de Unity desde el código

public class GameManager_scr : MonoBehaviour
{
    //string currentSceneName = SceneManager.GetActiveScene().name;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ReloadScene();
    }

    public static void ReloadScene()
    {
        if (Input.GetKey(KeyCode.R)) //al presionar la tecla R
        {
            SceneManager.LoadScene(0); //se recarga la escena
        }
    }


}
