using UnityEngine;

[CreateAssetMenu(fileName = "ChasePlayerBehavior", menuName = "Enemy Behaviors/Chase Player")]
public class ChasePlayerBehavior : SCRIPTABLE_EnemyBehavior
{
    [Tooltip("Distancia al jugador en la que el enemigo reducirá su velocidad.")]
    public float slowDownRadius = 2f;

    public override void ExecuteBehavior(SCRT_Enemy_DMGRecived_02 enemy)
    {
        GameObject player = GameObject.FindGameObjectWithTag("player");

        if (player != null)
        {
            // Calcular dirección hacia el jugador
            Vector3 direction = (player.transform.position - enemy.transform.position).normalized;

            // Calcular distancia al jugador
            float distance = Vector3.Distance(player.transform.position, enemy.transform.position);

            // Reducir la velocidad si está dentro del radio
            float currentSpeed = behaviorSpeed;
            if (distance < slowDownRadius)
            {
                currentSpeed *= 0.5f; // Reducir velocidad al 50%
            }

            // Mover al enemigo hacia el jugador
            enemy.transform.position += direction * currentSpeed * Time.deltaTime;
        }
    }
}
