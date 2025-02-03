using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public static CheckpointController instance;  // Instancia del CheckpointController
    private Transform checkpoint;  // Último checkpoint activado
    public GameObject player;  // Referencia al GameObject del jugador

    // Asegurarse de que solo haya una instancia del CheckpointController
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Esta función se llama cuando el jugador toca un checkpoint
    public void SetCheckpoint(Transform newCheckpoint)
    {
        checkpoint = newCheckpoint;  // Guarda el último checkpoint activado
    }

    // Esta función se llama cuando el jugador muere (o necesita respawnear)
    public void RespawnPlayer()
    {
        if (checkpoint != null)
        {
            player.transform.position = checkpoint.position;  // Respawnea al jugador en el último checkpoint activado
        }
        else
        {
            Debug.LogWarning("No se ha asignado un checkpoint.");
        }
    }

    // Script del Checkpoint (se adjunta a los objetos checkpoint)
    public class Checkpoint : MonoBehaviour
    {
        public bool isActivated = false;  // Para asegurarse de que solo se active una vez
        public Transform respawnPoint;  // El punto donde se respawnea al jugador

        private void OnTriggerEnter2D(Collider2D other)
        {
            // Verificamos si el objeto que toca el checkpoint es el jugador
            if (other.gameObject.CompareTag("Player"))
            {
                if (!isActivated)  // Solo se activa si no se había activado antes
                {
                    isActivated = true;  // Marca el checkpoint como activado
                    CheckpointController.instance.SetCheckpoint(respawnPoint);  // Le pasamos el nuevo punto de respawn al CheckpointController
                }
            }
        }
    }

    // Script del jugador (donde el jugador "muere" y se respawnea)
    public class Player : MonoBehaviour
    {
        // Aquí pueden ir tus variables de vida, animaciones, etc.

        private void Update()
        {
            // Simulamos la muerte del jugador presionando la tecla "R"
            if (Input.GetKeyDown(KeyCode.R))  
            {
                OnDeath();
            }
        }

        // Función que se llama cuando el jugador muere
        void OnDeath()
        {
            // Cuando el jugador "muere", respawnea en el último checkpoint
            CheckpointController.instance.RespawnPlayer();
        }
    }
}
