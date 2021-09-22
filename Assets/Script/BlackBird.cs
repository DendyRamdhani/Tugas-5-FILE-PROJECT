using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBird : Bird
{
    [SerializeField]
    public float impact ;
    public float sizeExplode;

    public LayerMask Layerhit;
    public GameObject ExplodeEffect;


    public void Explode()
    {
        if (State == BirdState.Thrown || State == BirdState.HitSomething)
        {
            Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, impact, Layerhit); 
            foreach(Collider2D obje in objects)
            {
                Vector2 direction = obje.transform.position - transform.position;
                obje.GetComponent<Rigidbody2D>().AddForce(direction * sizeExplode);
            }
            GameObject ExplodeEffectIns = Instantiate(ExplodeEffect, transform.position, Quaternion.identity);
            Destroy(ExplodeEffectIns, 10);
        }
    }
    public override void OnTap()
    {
        Explode();
    }
}
