using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfectoParalax : MonoBehaviour
{
    private Transform camaraTransform;
    private Vector3 ultimaPosicion;
    public float velocidadX;
    public float velocidadY; 

    // Start is called before the first frame update
    void Start()
    {
        camaraTransform = Camera.main.transform;
        ultimaPosicion = camaraTransform.position;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 movimiento = camaraTransform.position - ultimaPosicion;
        transform.position = transform.position + new Vector3(movimiento.x*velocidadX, movimiento.y*velocidadY, 0);
        ultimaPosicion = camaraTransform.position;
    }
}
