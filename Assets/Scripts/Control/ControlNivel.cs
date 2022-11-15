using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlNivel : MonoBehaviour
{

    //atributos
    protected PleyerStats stats;

    //Metodos de iniciacion generales
    private void Start()
    {
        stats = GameObject.FindGameObjectWithTag("GameData").GetComponent<PleyerStats>();
    }

    //Metodos
    public virtual void ColisionEnemigo(int danio){}
    public virtual void SumarPuntos(int p) { }

    public virtual IEnumerator ReiniciarNivel()
    {
        //hacer un efecto de camara, los vordes se oscurecen
        yield return new WaitForSeconds(0.5f);

        //recargo la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        yield return null;
    }

}
