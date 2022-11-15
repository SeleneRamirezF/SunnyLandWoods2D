using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlNivel1 : ControlNivel
{
    public int puntos;

    void Start()
    {
        puntos = 0;
        stats = GameObject.FindGameObjectWithTag("GameData").GetComponent<PleyerStats>();
    }

    private void Update()
    {
        //Debug.Log(stats.currentHP);
    }

    public override void ColisionEnemigo(int danio)
    {
        stats.currentHP -= danio;
        //Debug.Log(stats.currentHP);
        if (stats.currentHP <= 0)
        {
            //comprobar si muero
            StartCoroutine(ReiniciarNivel());
        }

        
    }

    public override void SumarPuntos(int p)
    {
        puntos += p;
        //si se llega a una cantidad de puntos de gana el nivel       
    }
}
