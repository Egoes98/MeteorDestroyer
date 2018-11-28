using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour {

    public KeyCode pause;
    public Canvas canvas;

    // Use this for initialization
    void Start() {
        canvas.GetComponentInChildren<Canvas>().enabled = false;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(pause))
        {
            if (Time.timeScale == 1)
            {    //si la velocidad es 1
                canvas.GetComponentInChildren<Canvas>().enabled = true;
                Time.timeScale = 0;     //que la velocidad del juego sea 0

            }
            else if (Time.timeScale == 0)
            {   // si la velocidad es 0
                canvas.GetComponentInChildren<Canvas>().enabled = false;
                Time.timeScale = 1;     // que la velocidad del juego regrese a 1
            }
        }
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //Se reinicia la escena
    }

    public void Continue()
    {
        canvas.GetComponentInChildren<Canvas>().enabled = false;
        Time.timeScale = 1;     //la velocidad del juego regrese a 1
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }

}
