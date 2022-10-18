using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJugador : MonoBehaviour
{
    public int velocidad;
    public int fuerzaSalto;
    public int numeroSaltos;
    public int numSaltados;

    private Rigidbody2D fisicas;
    private bool facingRight;
    private bool isInFloor;


    // Start is called before the first frame update
    void Start()
    {
        numSaltados = 0;
        facingRight = true;
        isInFloor = true;
        fisicas = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        MoverJugador();
        Giro();
        SaltoJugador();
    }

    public void MoverJugador()
    {
        float entradaX = Input.GetAxis("Horizontal");
        fisicas.velocity = new Vector2(entradaX * velocidad, fisicas.velocity.y);
    }

    private void Giro()
    {
        if (fisicas.velocity.x > 0.1 && !facingRight) Flip();
        if (fisicas.velocity.x < -0.1 && facingRight) Flip();
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 escala = transform.localScale;
        escala.x = escala.x * -1;
        transform.localScale = escala;
    }


    public void SaltoJugador()
    {
        if (TocaSuelo())
        {
            numSaltados = 0;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {            
            if (numSaltados < numeroSaltos)
            {
                numSaltados++;
                fisicas.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            }
            numSaltados++;
        }
    }

    private bool TocaSuelo()
    {
        //RaycastHit2D toca = Physics2D.Raycast(transform.position + new Vector3(0, -1.5f, 0), Vector2.down, 0.2f);
        //return toca.collider?.CompareTag("Floor") ?? false;
        return isInFloor;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Floor")) isInFloor = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Floor")) isInFloor = false;
    }





}
