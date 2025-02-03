using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void LoadMenu()
    {
        // Cargar la escena del juego
        SceneManager.LoadScene("pantallaInicio");
    }
    
    
    public void LoadGame()
    {
        // Cargar la escena del juego
        SceneManager.LoadScene("escenaPrado");
    }
    public void LoadCredits()
    {
        // Cargar la escena del juego
        SceneManager.LoadScene("creditos");
    }

    public void LoadSettings()
    {
        // Cargar la escena del juego
        SceneManager.LoadScene("escenaPrado");
    }
    public void CerrarJuego(){
        Application.Quit();
    }

}
