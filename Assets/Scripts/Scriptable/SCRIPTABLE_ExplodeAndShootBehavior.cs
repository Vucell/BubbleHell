using UnityEngine;

[CreateAssetMenu(fileName = "ExplodeAndShootBehavior", menuName = "Shoot Behaviors/Explode And Shoot")]
public class SCRIPTABLE_ExplodeAndShootBehavior : SCRIPTABLE_ShootBehavior
{
    [Header("Distance Settings")]
    public float approachDistance = 10f; // Distancia para comenzar a moverse hacia el player
    public float explodeDistance = 4f; // Distancia para activar la explosi�n
    public float explodeDelay = 2f; // Tiempo antes de explotar
    public float speed = 5f;

    [Header("Explosion Settings")]
    public int projectilesOnExplosion = 8; // Cantidad de proyectiles al explotar
    public float explosionProjectileSpeed = 8f; // Velocidad de los proyectiles

    public override void ExecuteBehavior(SCRT_Atack_Player player, Transform target)
    {
        if (player.projectilePrefab == null || player.firePoint == null) return;

        float distanceToTarget = Vector2.Distance(player.transform.position, target.position);

        // Si est� dentro del rango de "aproximaci�n", moverse hacia el target
        if (distanceToTarget <= approachDistance && distanceToTarget > explodeDistance)
        {
            Vector2 directionToTarget = (target.position - player.transform.position).normalized;
            player.transform.position += (Vector3)directionToTarget * speed * Time.deltaTime; // Movimiento hacia el jugador
            Debug.Log("Se Mueve");
        }
        // Si est� dentro del rango de "explosi�n", iniciar la explosi�n
        else if (distanceToTarget <= explodeDistance)
        {
            player.StartCoroutine(ExplodeAfterDelay(player));
        }
    }

    private System.Collections.IEnumerator ExplodeAfterDelay(SCRT_Atack_Player player)
    {
        yield return new WaitForSeconds(explodeDelay);

        // Generar proyectiles en direcciones aleatorias
        for (int i = 0; i < projectilesOnExplosion; i++)
        {
            float randomAngle = Random.Range(0f, 360f); // Generar un �ngulo aleatorio
            Vector2 randomDirection = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle)).normalized;

            GameObject projectile = Instantiate(player.projectilePrefab, player.transform.position, Quaternion.identity);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = randomDirection * explosionProjectileSpeed; // Asignar velocidad al proyectil
            }
        }

        Destroy(player.gameObject); // Destruir al enemigo
    }
}
