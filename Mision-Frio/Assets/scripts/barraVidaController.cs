using UnityEngine;
using UnityEngine.UI;

public class barraVidaController : MonoBehaviour
{
    private Image rellenoBarraVida;
    private playerController playerController;
    private float vidaMaxima;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerController=GameObject.Find("player").GetComponent<playerController>();
        vidaMaxima=playerController.vidaActual;
    }

    // Update is called once per frame
    void Update()
    {
        rellenoBarraVida.fillAmount= playerController.vidaActual/vidaMaxima;
    }
}
