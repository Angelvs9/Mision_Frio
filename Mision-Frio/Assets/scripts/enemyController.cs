using UnityEngine;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour
{
    public float velocidad;
    public float distanciaDeteccion = 15f; // Aumentamos la distancia de detección
    public float distanciaAtaque = 1.5f; // Ajustar la distancia para comenzar el ataque
    public List<Transform> puntosPatrulla; // Lista de puntos de patrulla
    public int dano;
    private Vector2 destinoPatrulla;
    private Animator animador;
    private Transform jugador;
    private bool persiguiendoJugador;
    public playerController playerController;
    public GameObject objetivo;

    void Start()
    {
        animador = GetComponent<Animator>();
        GenerarNuevoDestino();
    }

    void Update()
    {
        DetectarJugador();
        if (persiguiendoJugador)
        {
            PerseguirJugador();
        }
        else
        {
            Patrullar();
        }
    }

    void Patrullar()
    {
        if (puntosPatrulla.Count > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, destinoPatrulla, velocidad * Time.deltaTime);

            if (Vector2.Distance(transform.position, destinoPatrulla) > 0.1f)
            {
                animador.SetBool("moviendo", true);
            }
            else
            {
                animador.SetBool("moviendo", false);
                GenerarNuevoDestino();
            }
        }
    }

    void DetectarJugador()
    {
        jugador = GameObject.FindWithTag("Player")?.transform; // Asumiendo que el jugador tiene el tag "Player"
        if (jugador != null && Vector2.Distance(transform.position, jugador.position) <= distanciaDeteccion)
        {
            persiguiendoJugador = true;
            animador.SetBool("moviendo", true); // Asegurarse de que la animación de caminar esté activa
        }
        else
        {
            persiguiendoJugador = false;
            animador.SetBool("moviendo", true);
        }
    }

    void PerseguirJugador()
    {
        if (jugador != null)
        {
            float distanciaAlJugador = Vector2.Distance(transform.position, jugador.position);
            if (distanciaAlJugador > distanciaAtaque) // Sigue persiguiendo mientras no esté en rango de ataque
            {
                transform.position = Vector2.MoveTowards(transform.position, jugador.position, velocidad * Time.deltaTime);

                // Girar hacia el jugador
                if ((jugador.position.x < transform.position.x && transform.localScale.x > 0) ||
                    (jugador.position.x > transform.position.x && transform.localScale.x < 0))
                {
                    Vector3 escala = transform.localScale;
                    escala.x *= -1;
                    transform.localScale = escala;
                }
            }
            else
            {
                // Atacar al jugador
                animador.SetTrigger("atacar");
                playerController.vidaActual=playerController.vidaActual-dano;
                if(playerController.vidaActual<=0){
                    Destroy(objetivo);
                }
                animador.SetBool("moviendo", false); // Detener animación de caminar al atacar
            }
        }
    }

    void GenerarNuevoDestino()
    {
        if (puntosPatrulla.Count > 0 && !persiguiendoJugador)
        {
            int indicePatrulla = Random.Range(0, puntosPatrulla.Count);
            destinoPatrulla = puntosPatrulla[indicePatrulla].position;
            Flip();
        }
    }

    void Flip()
    {
        if (destinoPatrulla.x < transform.position.x && transform.localScale.x > 0 ||
            destinoPatrulla.x > transform.position.x && transform.localScale.x < 0)
        {
            Vector3 escala = transform.localScale;
            escala.x *= -1;
            transform.localScale = escala;
        }
    }
}
