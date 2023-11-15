using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    public int vidasRecuperadas = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ScoreTraker.instance.RecuperarVida(vidasRecuperadas);
            Destroy(this.gameObject);
        }
        
    }
}
