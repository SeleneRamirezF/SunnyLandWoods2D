using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverJugador : MonoBehaviour
{

    public int velocidad;
    private Rigidbody2D fisicas;
    private bool facingRight;

    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;
        fisicas = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Mover();
        Giro();
    }
    public void Mover()
    {
        float entradaX = Input.GetAxis("Horizontal");
        fisicas.velocity = new Vector2(entradaX * velocidad, fisicas.velocity.y);
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 escala = transform.localScale;
        escala.x = escala.x * -1;
        transform.localScale = escala;
    }

    private void Giro()
    {
        if (fisicas.velocity.x > 0.1 && !facingRight) Flip();
        if (fisicas.velocity.x < -0.1 && facingRight) Flip();
    }


}
