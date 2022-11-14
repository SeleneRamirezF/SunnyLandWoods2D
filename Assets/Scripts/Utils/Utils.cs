using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public static class Utils
    {
        public static bool TocaSuelo(GameObject g, float dist = 0.2f)
        {
            //float dist = -(g.GetComponent<Collider2D>().bounds.size.y);
            Vector3 centro = g.GetComponent<Collider2D>().bounds.center;
            //Vector3 destAbajo = new Vector3(0, -(g.GetComponent<Collider2D>().bounds.extents.y + 0.0001f));
            

            //RaycastHit2D toca = Physics2D.Raycast(g.transform.position + new Vector3(0, dist, 0), Vector2.down, 0.2f);
            //RaycastHit2D toca = Physics2D.Raycast(centro + destAbajo, Vector2.down, dist);

            Vector3 destAbajo1 = new Vector3(0, -(g.GetComponent<Collider2D>().bounds.extents.y + 0.0001f));
            RaycastHit2D toca1 = Physics2D.Raycast(centro + destAbajo1, Vector2.down, dist);

            Vector3 destAbajo2 = new Vector3(g.GetComponent<Collider2D>().bounds.extents.x, -(g.GetComponent<Collider2D>().bounds.extents.y + 0.0001f));
            RaycastHit2D toca2 = Physics2D.Raycast(centro + destAbajo2, Vector2.down, dist);

            Vector3 destAbajo3 = new Vector3(-g.GetComponent<Collider2D>().bounds.extents.x, -(g.GetComponent<Collider2D>().bounds.extents.y + 0.0001f));
            RaycastHit2D toca3 = Physics2D.Raycast(centro + destAbajo3, Vector2.down, dist);


            return (toca1.collider?.CompareTag("Floor") ?? false) || (toca2.collider?.CompareTag("Floor") ?? false) || (toca3.collider?.CompareTag("Floor") ?? false);
        }

        public static void Flip(GameObject gameObject)
        {
            //facingRight = !facingRight;
            Vector3 escala = gameObject.transform.localScale;
            escala.x = escala.x * -1;
            gameObject.transform.localScale = escala; //esto es lo que estamos modificando para el giro
        }
    }
}


