using UnityEngine;

[CreateAssetMenu(fileName = "TimedExplodeBehavior", menuName = "Shoot Behaviors/Timed Explode")]
public class SCRIPTABLE_TimedExplodeBehavior : SCRIPTABLE_ShootBehavior
{
    [Header("Timer Settings")]
    public float lifetime = 5f; // Tiempo antes de explotar automáticamente
    public float explodeDistance = 2f; // Distancia para detonar si está cerca del jugador
    public float explosionRadius = 5f; // Tamaño máximo de la onda expansiva
    public float explosionDuration = 1f; // Tiempo que tarda la onda en expandirse completamente

    [Header("Explosion Visuals")]
    public GameObject explosionPrefab; // Prefab para la onda expansiva

    public override void ExecuteBehavior(SCRT_Atack_Player player, Transform target)
    {
        if (player.projectilePrefab == null || explosionPrefab == null) return;

        player.StartCoroutine(HandleExplosion(player, target));
    }

    private System.Collections.IEnumerator HandleExplosion(SCRT_Atack_Player player, Transform target)
    {
        float timer = 0f;

        while (timer < lifetime)
        {
            timer += Time.deltaTime;

            // Verificar si está lo suficientemente cerca para explotar
            float distanceToTarget = Vector2.Distance(player.transform.position, target.position);
            if (distanceToTarget <= explodeDistance)
            {
                TriggerExplosion(player);
                yield break;
            }

            yield return null;
        }

        // Explosión automática al final del tiempo de vida
        TriggerExplosion(player);
    }

    private void TriggerExplosion(SCRT_Atack_Player player)
    {
        // Crear la onda expansiva
        GameObject explosion = Instantiate(explosionPrefab, player.transform.position, Quaternion.identity);
        SCRT_ExplosionWave wave = explosion.GetComponent<SCRT_ExplosionWave>();

        if (wave != null)
        {
            wave.Initialize(explosionRadius, explosionDuration);
        }

        // Destruir al enemigo
        Destroy(player.gameObject);
    }
}
