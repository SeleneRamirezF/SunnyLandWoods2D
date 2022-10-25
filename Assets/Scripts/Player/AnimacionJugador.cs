using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static Utils.Utils;

public class AnimacionJugador : MonoBehaviour
{

    private Animator animator;
    private Rigidbody2D fisicas;
    //private bool isInFloor;
    public enum AnimationOption {IDLE, RUN, JUMP, DROP};

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
        fisicas = gameObject.GetComponent<Rigidbody2D>();
        //isInFloor = true;
    }

    // Update is called once per frame
    void Update()
    {
        //AnimacionCodigo();
        AnimacionParametros();
    }

    private void AnimacionParametros()
    {
        animator.SetFloat("velocityX", Math.Abs(fisicas.velocity.x));
        animator.SetFloat("velocityY", fisicas.velocity.y);
        animator.SetBool("InFloor", TocaSuelo(gameObject));
        //animator.SetFloat("InFloor", fisicas.velocity.x);
        TocaSuelo(gameObject);
    }

    private void AnimacionCodigo()
    {
        
        if (Math.Abs(fisicas.velocity.y) > 1)
        {
            if (fisicas.velocity.y > 0)
            {
                //Salto
                animator.Play(AnimationOption.JUMP.ToString());
            }
            else
            {
                //caida
                animator.Play(AnimationOption.DROP.ToString());
            }
        }
        else if (Math.Abs(fisicas.velocity.x) > 1 && (fisicas.velocity.y <= 1))
        {
            //Correr
            animator.Play(AnimationOption.RUN.ToString());            
        }
        else
        {
            //Estatico
            animator.Play(AnimationOption.IDLE.ToString());
        }
           
    }

    /*private bool TocaSuelo()
    {
        RaycastHit2D toca = Physics2D.Raycast(transform.position + new Vector3(0, -1.5f, 0), Vector2.down, 0.2f);
        return isInFloor && (toca.collider?.CompareTag("Floor") ?? false);
    }*/




}
