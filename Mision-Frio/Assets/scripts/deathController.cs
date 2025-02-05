using UnityEngine;

public class deathController : MonoBehaviour
{
    public GameObject player;
    private Vector3[] checkpoints = 
    {
        new Vector3(-11.7f, 2.62f, 0f),   // Primer checkpoint
        new Vector3(105.01f, 3.996206f, 0f) // Segundo checkpoint
    };
    private int currentCheckpointIndex = 0; // Comienza en el primer checkpoint

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            RespawnPlayer();
        }
    }

    public void SetCheckpoint(int index)
    {
        if (index >= 0 && index < checkpoints.Length)
        {
            currentCheckpointIndex = index; // Actualiza el checkpoint actual
        }
    }

    public void RespawnPlayer()
    {
        player.transform.position = checkpoints[currentCheckpointIndex]; // Teletransporta al último checkpoint
    }
}
