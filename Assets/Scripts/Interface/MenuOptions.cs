using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOptions : MonoBehaviour
{
    public GameObject PauseButton;  
    public GameObject GrupoPausa;    
    public GameObject GrupoSettings; 

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

    public void PlayGame(string NameScene)
    {
        SceneManager.LoadScene(NameScene);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void IrAlMenu(string NombreMenu)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(NombreMenu, LoadSceneMode.Single);
    }

    private void TogglePauseMenu()
    {
        if (GrupoSettings.activeSelf) return; 

        bool isPaused = GrupoPausa.activeSelf;  

        PauseButton.SetActive(isPaused);
        GrupoPausa.SetActive(!isPaused);
        Time.timeScale = isPaused ? 1 : 0;
    }

    public void OpenSettings()
    {
        PauseButton.SetActive(false);
        GrupoPausa.SetActive(false);
        GrupoSettings.SetActive(true);
    }

    private void CloseAllMenus()
    {
        PauseButton.SetActive(true);
        GrupoPausa.SetActive(false);
        GrupoSettings.SetActive(false);
        Time.timeScale = 1;
    }
}
