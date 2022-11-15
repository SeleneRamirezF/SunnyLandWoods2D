using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlColeccionablePuntos : MonoBehaviour
{
    ControlNivel control;
    public int puntos;

    void Start()
    {
        control = GameObject.FindGameObjectWithTag("GameController").GetComponent<ControlNivel>();
        if (!control) Debug.LogError("ERROR: Debes tener un Controlador de Nivel en la escena");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            control.SumarPuntos(puntos);
            Destroy(gameObject);
        }
    }
}
