using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverJugador : MonoBehaviour
{

    //public int velocidad;
    private Rigidbody2D fisicas;
    private bool facingRight;
    private PleyerStats stats;
    public bool bloquearMovimiento;

    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;
        fisicas = gameObject.GetComponent<Rigidbody2D>();
        stats = GameObject.FindGameObjectWithTag("GameData").GetComponent<PleyerStats>();
        bloquearMovimiento = false;
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
        //fisicas.velocity = new Vector2(entradaX * stats.speed, fisicas.velocity.y);
        if (!bloquearMovimiento)
        {
            fisicas.velocity = new Vector2(entradaX * stats.speed, fisicas.velocity.y);
        }
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

    public IEnumerator KnockBackJugador(Vector3 direccion)
    {
        bloquearMovimiento = true;
        fisicas.AddForce(direccion * stats.forceKnockBack, ForceMode2D.Impulse);

        yield return new WaitForFixedUpdate();
        yield return new WaitForSecondsRealtime(0.5f);

        bloquearMovimiento = false;
    }
}
