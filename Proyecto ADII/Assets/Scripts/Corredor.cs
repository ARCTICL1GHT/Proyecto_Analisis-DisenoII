using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Corredor : MonoBehaviour
{
    // variables para el desarrollo del juego
    public static int rondas = 3;
    public Text lbrondas;
    public Text Ganador;
    // variables del personaje
    public float speed = 5.0f;
    public Sprite izquierda;
    public Sprite derecha;
    public Sprite centro;
    public Perseguido perseguido;
    public int ganadas = 0;
    // Start is called before the first frame update
    void Start()
    {
        lbrondas.text = "Rondas: " + rondas;
    }

    // Update is called once per frame
    void Update()
    {
        // Movimiento
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = izquierda;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = derecha;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = centro;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = centro;
        }
        // fin del juego
        if (rondas == 0)
        {
            StartCoroutine(ShowMessage(2));
        }
    }

    // si entra en contacto con otro objeto
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Limites (paredes)
        if (collision.gameObject.tag == "limite")
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(speed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(-speed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(0, -speed * Time.deltaTime, 0);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(0, speed * Time.deltaTime, 0);
            }
        }
        // coliciona con el enemigo
        if (collision.gameObject.tag == "perseguido")
        {
            // restar uno a las rondas jugadas
            rondamenos();
            // reiniciar sus posiciones
            starPosition();
            // sumar una ronda ganada
            ganadas++;
            //reiniciar el timer
            perseguido.restarTimer();
            
        }


    }

    public void rondamenos()
    {
        rondas--;
        Debug.Log(rondas);
        lbrondas.text = "Rondas: " + rondas;
    }

    public void starPosition()
    {
        transform.position = new Vector3(-8.78f, 1.94f, 0);
        perseguido.starPosition();
    }

    public IEnumerator ShowMessage(float delay)
    {
        if (ganadas > perseguido.ganadas)
        {
            Ganador.text = "!!Gano el corredor!!";
        }
        else
        {
            Ganador.text = "!!Gano el perseguido!!";
        }
        yield return new WaitForSeconds(delay);
        Ganador.text = "";
        rondas = 3;
        lbrondas.text = "Rondas: " + rondas;
        SceneManager.LoadScene("MainMenu");
    }
}
