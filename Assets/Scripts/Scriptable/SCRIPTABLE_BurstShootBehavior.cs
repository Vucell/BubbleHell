using UnityEngine;

[CreateAssetMenu(fileName = "BurstShootBehavior", menuName = "Shoot Behaviors/Burst Shoot")]
public class SCRIPTABLE_BurstShootBehavior : SCRIPTABLE_ShootBehavior
{
    public int burstCount = 3; // Cantidad de proyectiles
    public float angleBetweenProjectiles = 10f; // Angulo entre proyectiles
    public float SpeedShot = 10f;

    public override void ExecuteBehavior(SCRT_Atack_Player player, Transform target)
    {
        if (player.projectilePrefab != null && player.firePoint != null)
        {
            for (int i = 0; i < burstCount; i++)
            {
                // Calcular el �ngulo de disparo
                float angleOffset = (i - (burstCount - 1) / 2f) * angleBetweenProjectiles;

                // Calcular la direccion del proyectil
                Vector2 direction = (target.position - player.firePoint.position).normalized;
                direction = Quaternion.Euler(0, 0, angleOffset) * direction;

                // Crear el proyectil
                GameObject projectile = Instantiate(player.projectilePrefab, player.firePoint.position, Quaternion.identity);
                Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.linearVelocity = direction * SpeedShot; // Puedes ajustar la velocidad del proyectil aquí
                }
            }
        }
    }
}
