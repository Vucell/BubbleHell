using UnityEngine;

public class SCRT_proyectile_Player : MonoBehaviour
{
    [Tooltip("Velocidad del proyectil.")]
    public float speed = 10f;

    private Vector2 direction;

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
    }

    private void Update()
    {
        // Mover el proyectil en la direcci�n asignada
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        // Detectar si el proyectil impacta con un enemigo
        if (collision.CompareTag("enemy"))
        {
            // Aqu� podr�as implementar l�gica adicional, como reducir vida al enemigo
            //Destroy(collision.gameObject); // Destruir el enemigo
            Destroy(gameObject); // Destruir el proyectil
        }
    }
}
