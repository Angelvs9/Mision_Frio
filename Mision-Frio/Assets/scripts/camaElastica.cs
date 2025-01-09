using UnityEngine;

public class camaElastica : MonoBehaviour
{
    private Rigidbody2D rb;

    public float bounceForce = 600f;  // Fuerza que se aplicará al objeto al rebotar

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Obtén el Rigidbody2D del objeto
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.CompareTag("trampolin"))
        {
            Debug.Log("llego");
            // Aplica una fuerza hacia arriba (en el eje Y) para simular el rebote
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);  // Restablece la velocidad vertical para evitar acumulación
            rb.AddForce(Vector2.up * bounceForce);  // Aplica la fuerza de impulso
        }
    }
}
