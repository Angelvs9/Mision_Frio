using UnityEngine;
using UnityEngine.UI;

public class barraVidaController : MonoBehaviour
{
    public Slider barraVida;  // Slider de la barra de vida
    public playerController pc;  // Referencia al PlayerController
    public float vidaMaxima;  // Vida máxima (esto será obtenido del playerController)

    // Start es llamado antes del primer frame de actualización
    void Start()
    {
        // Asegurarse de que la referencia al playerController está asignada
        if (pc != null)
        {
            vidaMaxima = pc.vidaMaxima;  // Obtener vida máxima del playerController
            ActualizarBarraVida(pc.vidaMaxima);  // Iniciar la barra de vida con la vida actual
        }
    }

    // Método para actualizar la barra de vida
    public void ActualizarBarraVida(float vidaActual)
    {
         if (barraVida != null) // Verifica que el Slider no sea nulo
        {
           barraVida.value = vidaActual;  // Calculamos el porcentaje de vida
        }
        else
        {
            Debug.LogError("Slider no asignado en el Inspector.");
        }
     
    }
}
