using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestaVida : MonoBehaviour
{
    public int dano = 1;

    public void OnTriggerEnter(Collider collision)
    {
        ScoreTraker.instance.ReceiveDamage(dano);

        Destroy(this.gameObject);
    }
}
