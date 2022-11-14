using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static Utils.Utils;

public class ControlEnemigoPatrulla : MonoBehaviour
{
    //movimiento
    public float velocidad;
    //public Vector3 posicionInicial;
    //public Vector3 posicionFinal;
    public List<Vector3> posiciones;
    public int moviendoAPosicion;

    //Patrulla general
    //private Vector3 destino;
    private bool facingRight;
    private Vector3 posicionInicial;

    //patrulla gameObject    
    public enum modosPatrulla
    {
        GameObject,
        Posiciones
    };
    public modosPatrulla modo;

    //control corrutila
    //private bool ejecutandoCourrutina;
    public int tiempoEspera;


    void Start()
    {
        //movimiento
        facingRight = true;
        //destino = posicionFinal;

        //Patrulla general        
        moviendoAPosicion = 0;

        if(modo == modosPatrulla.Posiciones)
        {
            //patrulla Posiciones
            posicionInicial = transform.position;
            posiciones.Add(Vector3.zero);
        }
        else
        {
            //patrulla GameObject
            posicionInicial = Vector3.zero;
            posiciones.Clear();
            GameObject patrulla = gameObject.transform.Find("Patrulla").gameObject;
            for (int i = 0; i < patrulla.transform.childCount; i++)
            {
                posiciones.Add(patrulla.transform.GetChild(i).position);
            }
        }

        //Control Corrutina
        StartCoroutine(Patrulla());
    }

    public void MoverEnemigo()//Vector3 destino)
    {
        //transform.position = Vector3.MoveTowards(transform.position, destino, velocidad * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, posicionInicial + posiciones[moviendoAPosicion], velocidad * Time.deltaTime);
    }

    public IEnumerator Patrulla()
    //public void Patrulla()
    {
        /*if (Vector3.Distance(transform.position, destino) < 0.2)
        {
            if (transform.position == posicionFinal) destino = posicionInicial;
            else destino = posicionFinal;            
        }*/
        MoverEnemigo();

        if (Vector3.Distance(transform.position, posicionInicial + posiciones[moviendoAPosicion]) < 0.2)
        {
            moviendoAPosicion = (moviendoAPosicion + 1) % posiciones.Count;
            yield return StartCoroutine(Espera());
        }

        ControlGiro();
        yield return new WaitForSeconds(0);
        yield return StartCoroutine(Patrulla());
    }

    private IEnumerator Espera()
    {
        yield return new WaitForSeconds(tiempoEspera);
    }

    public void ControlGiro()
    {
        //if (transform.position.x < destino.x && facingRight)
        if (transform.position.x < (posicionInicial + posiciones[moviendoAPosicion]).x && facingRight)
        {
            facingRight = !facingRight;
            Flip(gameObject);
        }
        //if (transform.position.x > destino.x && !facingRight)
        if (transform.position.x > (posicionInicial + posiciones[moviendoAPosicion]).x && !facingRight)
        {
            facingRight = !facingRight;
            Flip(gameObject);
        }
    }

    void Update()
    {     
        //MoverEnemigo(destino);
        //MoverEnemigo();
        //Patrulla();        
    }
}
