using UnityEngine;

public class deathZoneController : MonoBehaviour
{
    public CheckpointController instance2; 
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
       instance2.RespawnPlayer(player);
    }
}
