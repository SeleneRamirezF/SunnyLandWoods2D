using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoColisionController : MonoBehaviour
{
    ControlNivel control;
    public int danio;

    void Start()
    {
        control = GameObject.FindGameObjectWithTag("GameController").GetComponent<ControlNivel>();
        if(!control) Debug.LogError("ERROR: Debes tener un Controlador de Nivel en la escena");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            control.ColisionEnemigo(danio);
        }
    }
}
