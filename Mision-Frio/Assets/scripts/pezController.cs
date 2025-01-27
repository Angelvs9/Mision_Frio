using UnityEngine;
using UnityEngine.UI;

public class pezController : MonoBehaviour
{
    public Image fishIcon;        // Asigna el objeto de la UI FishIcon desde el Inspector
    public Sprite pezGris;        // Asigna el sprite gris desde el Inspector
    public Sprite pez;            // Asigna el sprite naranja desde el Inspector

    void Start()
    {

        if (fishIcon != null)
        {
            fishIcon.sprite = pezGris;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            // Cambiar al sprite naranja cuando se recoja el pez
            fishIcon.sprite = pez;

            // Desactivar el objeto del pez
            gameObject.SetActive(false);
        }
    }
}
