using UnityEngine;
using UnityEngine.SceneManagement;

public class MetaController : MonoBehaviour
{
    public GameObject player;

    public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject==player)
            {
                //cambiar por la escerna del nivel 2
                SceneManager.LoadScene("creditos");
            }
        }
}
