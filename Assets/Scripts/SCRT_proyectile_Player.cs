using System;
using UnityEngine;

public class SCRT_proyectile_Player : MonoBehaviour
{
    [Tooltip("Velocidad del proyectil.")]
    public float speed = 10f;

    public float damage = 5f;

    private Vector2 direction;

    public string objective;

    public bool EnemyShoot;

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

        // Detectar si el proyectil impacta con un enemigo
        if (collision.CompareTag("player") && true == EnemyShoot)
        {
            // Aquí podrías implementar lógica adicional, como reducir vida al enemigo
            //Destroy(collision.gameObject); // Destruir el enemigo

            Destroy(gameObject); // Destruir el proyectil
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("enemy") && false == EnemyShoot)
        {
            SCRT_Enemy_DMGRecived_02 enemy = collision.GetComponent<SCRT_Enemy_DMGRecived_02>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage); // "Damage" es el float de tu proyectil.
            }

            Destroy(gameObject); // Destruir el proyectil.
        }
        if (collision.CompareTag("border"))
        {
            Destroy(gameObject);
        }
    }
}
