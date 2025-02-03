using UnityEngine;

public class playerController : MonoBehaviour
{

    private AudioSource audioSource;  
    public AudioClip saltoSonido;
    public barraVidaController barraVida;
    public AudioClip ataqueSonido;

    private bool puedeSaltar; 
    private Animator ataque;
    private int contador;
    public string ultimoSuelo="";

    public float velocidadMaxima=2f;
    public float peso=1f;
    public float fuerzaSalto=100f;


    [SerializeField] public barraVidaController barraVidaController;
    public float vidaMaxima = 10;
    public float vidaActual;
    public GameObject player;

    //private int danojugador=5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
          ataque=gameObject.GetComponent<Animator>();
          contador=0;
          vidaActual = vidaMaxima;
          audioSource=GetComponent<AudioSource>();
          saltoSonido=Resources.Load<AudioClip>("sounds/saltoSonido");
          ataqueSonido=Resources.Load<AudioClip>("sounds/ataqueSonido");
        
    }

    // Update is called once per frame
    void Update()
    {


          ControlInactividad(); // Llamar al método que el baile
          
          // Movimiento y acciones del personaje
          if (Input.anyKey || Input.anyKeyDown)
          {
               contador = 0; // Reiniciar el contador de inactividad
               gameObject.GetComponent<Animator>().SetBool("bailando", false); // Detener baile

               if (Input.GetKey("left") || Input.GetKey("a"))
               {
                    gameObject.GetComponent<SpriteRenderer>().flipX = true;
                    // gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-700f * Time.deltaTime, 0));   
                   
                    if(!puedeSaltar){
                         //para maniobrar mejor en el aire pillo un velocidad mas baja 
                         float nuevaVelocidad=Mathf.Clamp(gameObject.GetComponent<Rigidbody2D>().linearVelocity.x - 50f * Time.deltaTime, -velocidadMaxima, velocidadMaxima);
                         gameObject.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(nuevaVelocidad, gameObject.GetComponent<Rigidbody2D>().linearVelocity.y);
                    }else{
                         float nuevaVelocidad=Mathf.Clamp(gameObject.GetComponent<Rigidbody2D>().linearVelocity.x - 700f * Time.deltaTime, -velocidadMaxima, velocidadMaxima);
                         gameObject.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(nuevaVelocidad, gameObject.GetComponent<Rigidbody2D>().linearVelocity.y);
                    }

                    gameObject.GetComponent<Animator>().SetBool("moviendo", true);
                    gameObject.GetComponent<Animator>().SetBool("saltar", false);
               }

               if (Input.GetKey("right") || Input.GetKey("d"))
               {
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;
               //     gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(700f * Time.deltaTime, 0));   
                    
                    if(!puedeSaltar){
                         //para maniobrar mejor en el aire pillo un velocidad mas baja 
                         float nuevaVelocidad=Mathf.Clamp(gameObject.GetComponent<Rigidbody2D>().linearVelocity.x + 50f * Time.deltaTime, -velocidadMaxima, velocidadMaxima);
                         gameObject.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(nuevaVelocidad, gameObject.GetComponent<Rigidbody2D>().linearVelocity.y);
                    }else{
                         float nuevaVelocidad=Mathf.Clamp(gameObject.GetComponent<Rigidbody2D>().linearVelocity.x + 700f * Time.deltaTime, -velocidadMaxima, velocidadMaxima);
                         gameObject.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(nuevaVelocidad, gameObject.GetComponent<Rigidbody2D>().linearVelocity.y);
                    }

                    gameObject.GetComponent<Animator>().SetBool("moviendo", true);
                    gameObject.GetComponent<Animator>().SetBool("saltar", false);

               }

               if ((Input.GetKeyDown("up") || Input.GetKeyDown("space")) && puedeSaltar)
               {
                    puedeSaltar = false;
                    audioSource.pitch = Random.Range(0.8f, 1.2f);
                    audioSource.PlayOneShot(saltoSonido);
                    gameObject.GetComponent<Animator>().SetBool("tocarsuelo", false);
                    gameObject.GetComponent<Animator>().SetBool("saltar", true);
                    gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,fuerzaSalto)); // Ajusta este valor para controlar la fuerza del salto
               }

               if (!(Input.GetKey("left") || Input.GetKey("a")) && !(Input.GetKey("right") || Input.GetKey("d")))
               {
                    gameObject.GetComponent<Animator>().SetBool("moviendo", false);

               }
              
               atacar();
          }
          
    }

     private void ControlInactividad(){
        if (!Input.anyKey && !Input.anyKeyDown)
        {
          gameObject.GetComponent<Animator>().SetBool("moviendo", false);
            contador++; // Incrementar el contador si no se presiona ninguna tecla
            if (contador >= 1000)
               gameObject.GetComponent<Animator>().SetBool("bailando", true); // Activar animación de baile
        }
    }



     private void OnCollisionEnter2D(Collision2D collision){
          if(collision.transform.tag=="suelo" ){    
               puedeSaltar=true;
                    gameObject.GetComponent<Animator>().SetBool("tocarsuelo", true);
                    gameObject.GetComponent<Animator>().SetBool("saltar",false);
               
          }
          ultimoSuelo=collision.transform.tag;
          
     }


     private void OnCollisionExit2D(Collision2D collision){
          //lo del ultimo suelo es para lo de aplastar 
          if(collision.transform.tag=="suelo" && ultimoSuelo!=collision.transform.tag){    
               puedeSaltar=false;
               gameObject.GetComponent<Animator>().SetBool("tocarsuelo", false);
               gameObject.GetComponent<Animator>().SetBool("saltar",true);
          }
          
     }

     private void atacar(){
          if(Input.GetMouseButtonDown(0)){
               ataque.SetTrigger("atacar");
               audioSource.pitch = Random.Range(0.8f, 1.2f);
               audioSource.PlayOneShot(ataqueSonido);
               
          }
     }

     public void RecibirDaño(float dano)
     {
          vidaActual-=dano;
          cambiarBarraVida();
          if(vidaActual<=0){ Destroy(gameObject);}
     }

     private void cambiarBarraVida(){
          if(barraVida!=null){
               barraVida.ActualizarBarraVida(vidaActual);
          }
     }


}
