using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltoJugador : MonoBehaviour
{
    private bool isInFloor;
    public int numeroSaltos;
    public int numSaltados;
    private Rigidbody2D fisicas;
    public int fuerzaSalto;

    // Start is called before the first frame update
    void Start()
    {
        numSaltados = 0;
        isInFloor = true;
        fisicas = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Saltar();
    }

    public void Saltar()
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
        RaycastHit2D toca = Physics2D.Raycast(transform.position + new Vector3(0, -1.5f, 0), Vector2.down, 0.2f);
        //return toca.collider?.CompareTag("Floor") ?? false;
        return isInFloor && (toca.collider?.CompareTag("Floor") ?? false);
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
