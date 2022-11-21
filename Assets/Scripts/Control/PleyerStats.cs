using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PleyerStats : MonoBehaviour
{
    //Atributos de vida
    public int currentHP;
    public int maxHP;

    //Atributos de movimiento
    public int jumpMax;
    public int jumpForce;
    public int speed;
    public int forceKnockBack;

    //Invulnerabilidad
    public bool invulnerable;    
    public int segundosInvulnerable;

}
