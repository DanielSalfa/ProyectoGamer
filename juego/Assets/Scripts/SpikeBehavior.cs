using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBehavior : MonoBehaviour
{
    public int dano = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ScoreTraker.instance.ReceiveDamage(dano);
    }
}
