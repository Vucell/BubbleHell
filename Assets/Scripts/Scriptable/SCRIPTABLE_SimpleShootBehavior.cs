using UnityEngine;

[CreateAssetMenu(fileName = "SimpleShootBehavior", menuName = "Shoot Behaviors/Simple Shoot")]
public class SCRIPTABLE_SimpleShootBehavior : SCRIPTABLE_ShootBehavior
{
    public override void ExecuteBehavior(SCRT_Atack_Player player, Transform target)
    {
        if (player.projectilePrefab != null && player.firePoint != null)
        {
            // Crear el proyectil en el firePoint
            GameObject projectile = Instantiate(player.projectilePrefab, player.firePoint.position, Quaternion.identity);

            // Direccionar el proyectil hacia el enemigo
            Vector2 direction = (target.position - player.firePoint.position).normalized;
            projectile.GetComponent<SCRT_proyectile_Player>().SetDirection(direction);
        }
    }
}
