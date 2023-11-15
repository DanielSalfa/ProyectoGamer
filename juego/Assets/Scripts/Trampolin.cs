using UnityEngine;

public class Trampolin : MonoBehaviour
{
    public float fuerzaImpulso = 10f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Verificar si el objeto que colisionó es el jugador
            Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();

            if (playerRb != null)
            {
                // Aplicar fuerza hacia arriba al jugador
                playerRb.velocity = new Vector2(playerRb.velocity.x, 0); // Restablecer la velocidad vertical
                playerRb.AddForce(Vector2.up * fuerzaImpulso, ForceMode2D.Impulse);
            }
        }
    }
}
