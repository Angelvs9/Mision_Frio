using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    //public static CheckpointController instance;  // Instancia de CheckpointController


    void Awake()
    {

    }

    public void RespawnPlayer(GameObject player)
    {
        // Teletransporta al jugador a las coordenadas específicas
        player.transform.position = new Vector3(-11.7f, 2.62f, 0f);  // Coordenadas de reaparecer

    }
}
