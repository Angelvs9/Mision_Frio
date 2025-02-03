using UnityEngine;

public class deathZoneController : MonoBehaviour
{
    public static CheckpointController instance; 
    public GameObject player;

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            PlayerDeath();
        }
    }

    
    private void PlayerDeath()
    {
        CheckpointController.instance.RespawnPlayer(player);
    }
}
