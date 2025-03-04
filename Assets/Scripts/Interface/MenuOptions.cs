using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOptions : MonoBehaviour
{
    public GameObject ObjetoMenuPausa;
    public bool Pausa;
    public GameObject PauseButton;  
    public GameObject GrupoPausa;    
    public GameObject GrupoSalir;    
    public GameObject GrupoSettings; 

    //gestiona la apertura y cierre del menú de pausa o configuración cuando el jugador presiona la tecla Escape.
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GrupoSettings.activeSelf)
            {
                CloseAllMenus(); 
            }
            else
            {
                TogglePauseMenu(); 
            }
        }
    }

    //activa el menú de pausa y detiene el tiempo en el juego.
    public void PausarJuego()
    {        
        GrupoPausa.SetActive(true);
        GrupoSalir.SetActive(false);
        GrupoSettings.SetActive(false);
        PauseButton.SetActive(false);
        ObjetoMenuPausa.SetActive(true);
        Pausa = true;
        Time.timeScale = 0;
    }

    //desactiva el menú de pausa y reanuda el juego.
    public void Reanudar()
    {
        GrupoPausa.SetActive(false);
        GrupoSalir.SetActive(false);
        GrupoSettings.SetActive(false);
        PauseButton.SetActive(true);
        Pausa = false;
        Time.timeScale = 1;
    }

    //carga una nueva escena según el nombre que se le pase como parámetro.
    public void PlayGame(string NameScene)
    {
        SceneManager.LoadScene(NameScene);
    }

    //sirve para cerrar el juego en una compilación ejecutable (Windows, Mac, Android, etc.) (Osea que en itch.io, está de decoración :(, pero igual lo puse por si mas adelante).
    public void Quit()
    {
        Application.Quit();
    }

    //carga una escena, (MainMenu) y reanuda el tiempo del juego si estaba pausado.
    public void IrAlMenu(string NombreMenu)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(NombreMenu, LoadSceneMode.Single);
    }

    //alterna el estado del menú de pausa y ajusta el tiempo del juego en consecuencia.
    private void TogglePauseMenu()
    {
        if (GrupoSettings.activeSelf) return; 

        bool isPaused = GrupoPausa.activeSelf;  

        PauseButton.SetActive(isPaused);
        GrupoPausa.SetActive(!isPaused);
        Time.timeScale = isPaused ? 1 : 0;
    }

    //abre el menú de configuración desde el menú de pausa.
    public void OpenSettings()
    {
        PauseButton.SetActive(false);
        GrupoPausa.SetActive(false);
        GrupoSettings.SetActive(true);
    }

    //cierra todos los menús y reanuda el juego
    private void CloseAllMenus()
    {
        PauseButton.SetActive(true);
        GrupoPausa.SetActive(false);
        GrupoSettings.SetActive(false);
        Time.timeScale = 1;
    }
}
