using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int valor = 100;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreTraker.instance.addScore(valor);
        
        Destroy(this.gameObject);
    }
}
