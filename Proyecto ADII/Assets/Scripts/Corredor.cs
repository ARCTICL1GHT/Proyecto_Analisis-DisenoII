using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corredor : MonoBehaviour
{
    // variables del personaje
    public float speed = 5.0f;
    public Sprite izquierda;
    public Sprite derecha;
    public Sprite centro;
    // Start is called before the first frame update
    void Start()
    {
        
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


    }
}
