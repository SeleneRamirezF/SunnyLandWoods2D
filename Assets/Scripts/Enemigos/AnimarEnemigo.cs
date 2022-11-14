using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Utils.Utils;

public class AnimarEnemigo : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D fisicas;
    private Vector3 posiciónAnterior;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
        fisicas = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("InFloor", TocaSuelo(gameObject));
        animator.SetFloat("velocityY", transform.position.y - posiciónAnterior.y);

        posiciónAnterior = transform.position;
    }
}
