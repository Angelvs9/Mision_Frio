using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void LoadGame()
    {
        // Cargar la escena del juego
        SceneManager.LoadScene("escenaPrado");
    }
}
