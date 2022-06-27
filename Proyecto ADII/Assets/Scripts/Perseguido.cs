using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Perseguido : MonoBehaviour
{
    //Texto
    public Text contador;
    // timer
    float tiempoactual = 0f;
    float tiempoinicial = 120f; // 2 minutos por ronda
    // variables del personaje
    public float speed = 5.0f;
    public Sprite izquierda;
    public Sprite derecha;
    public Sprite centro;
    public Corredor corredor;
    public int ganadas = 0;
    // Start is called before the first frame update
    void Start()
    {
        // inicial el contador 
        tiempoactual = tiempoinicial;
    }

    // Update is called once per frame
    void Update()
    {
        // Movimiento
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = izquierda;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = derecha;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = centro;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = centro;
        }
        // timer
        tiempoactual -= 1 * Time.deltaTime;
        contador.text = "Tiempo: "
            + tiempoactual.ToString("0");

        if (tiempoactual <= 0)
        {
            // reiniciar el timer
            tiempoactual = 120f;
            // restar ronda
            corredor.rondamenos();
            // ronga ganada
            ganadas++;
            // regresar a sus posiciones
            starPosition();
            corredor.starPosition();


        }
    }

    // si entra en contacto con otro objeto
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Limites (paredes)
        if (collision.gameObject.tag == "limite")
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(speed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(-speed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(0, -speed * Time.deltaTime, 0);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(0, speed * Time.deltaTime, 0);
            }
        }


    }
    public void restarTimer()
    {
        tiempoactual = 120f;
    }

    public void starPosition()
    {
        transform.position = new Vector3(7.51f, -3.57f, 0);
        
    }
}
