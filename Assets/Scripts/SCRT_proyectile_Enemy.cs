using UnityEngine;

public class SCRT_proyectile_Enemy : MonoBehaviour
{
    [Tooltip("Velocidad del proyectil.")]
    public float speed = 10f;

    public float damage = 5f;

    public Vector2 direction;

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
    }

    private void Update()
    {
        // Mover el proyectil en la dirección asignada
        transform.Translate(direction * speed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("player"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject); // Destruir el proyectil.
        }
    }
}
