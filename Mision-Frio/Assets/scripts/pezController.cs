using UnityEngine;

public class pezController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision){
        gameObject.SetActive(false);
    }
    
}
