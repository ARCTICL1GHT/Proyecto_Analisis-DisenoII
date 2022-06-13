using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Malvado_Movment : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }


    // Update is called once per frame
    void Update()
    {
       
    }
    
    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        moveDelta = new Vector3(x,y,0);
        if(moveDelta.x >0)
            transform.localScale = new Vector3(-4, 4, 1);
        else if(moveDelta.x < 0)
            transform.localScale = new Vector3(4, 4, 1);

        transform.Translate(moveDelta*Time.deltaTime);
    }
}
