using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlNivel1 : ControlNivel
{
    public int puntos;

    private GameObject player;
    


    void Start()
    {
        stats = GameObject.FindGameObjectWithTag("GameData").GetComponent<PleyerStats>();
        player = GameObject.FindGameObjectWithTag("Player");

        stats.invulnerable = false;
        puntos = 0;

    }

    private void Update()
    {
        //Debug.Log(stats.currentHP);
    }

    public override void SumarPuntos(int p)
    {
        puntos += p;
        //si se llega a una cantidad de puntos de gana el nivel       
    }

    public override void PlayerRecivirDanio(int danio, GameObject origenDanio)
    {
        if (!stats.invulnerable)
        {
            //comprobar si muero
            StartCoroutine(CorutinaPlayerRecivirDanio(danio, origenDanio));
        }        
    }

    private IEnumerator CorutinaPlayerRecivirDanio(int danio , GameObject origenDanio)
    {
        stats.invulnerable = true;
        player.GetComponentInChildren<SpriteRenderer>().color = Color.red;

        //probar a saltar hacia atras al tocar enemigo y recivir daño
        Vector3 direction = (player.transform.position - origenDanio.transform.position).normalized;
        yield return player.GetComponentInChildren<MoverJugador>().KnockBackJugador(direction);

        //calculo del danio
        stats.currentHP -= danio;
        if (stats.currentHP <= 0)
        {
            yield return StartCoroutine(ReiniciarNivel());
        }
        yield return new WaitForSecondsRealtime(stats.segundosInvulnerable);

        player.GetComponentInChildren<SpriteRenderer>().color = Color.white;
        stats.invulnerable = false;

        yield return null;
    }
}
