using System.Collections.Generic;
using UnityEngine;

public class SCRT_Atack_Enemy : MonoBehaviour
{
    [Header("Attack Settings")]
    [Tooltip("Radio de alcance para detectar jugadores.")]
    public float attackRange = 5f; // Radio de alcance

    [Tooltip("Tiempo entre disparos (en segundos).")]
    public float timeBetweenShots = 1f; // Tiempo entre disparos

    [Tooltip("Punto desde el que se disparan los proyectiles.")]
    public Transform firePoint; // Punto de disparo

    [Tooltip("Prefab del proyectil que dispara el enemigo.")]
    public GameObject projectilePrefab; // Prefab del proyectil

    [Header("Behavior Settings")]
    [Tooltip("Lista de comportamientos de disparo del enemigo.")]
    public List<SCRIPTABLE_ShootBehavior> behaviors; // Lista de comportamientos

    private float shotTimer = 0f; // Temporizador entre disparos

    private void Update()
    {
        // Incrementar el temporizador de disparo
        shotTimer += Time.deltaTime;

        // Buscar al jugador más cercano dentro del rango
        GameObject closestPlayer = FindClosestPlayer();

        if (behaviors != null && behaviors.Count > 0 && closestPlayer != null && shotTimer >= timeBetweenShots)
        {
            // Ejecutar todos los comportamientos en la lista
            foreach (var behavior in behaviors)
            {
                //behavior.ExecuteBehavior(this, closestPlayer.transform); // Pasar referencia del enemigo y del jugador
            }

            shotTimer = 0f; // Reiniciar el temporizador
        }
    }

    private GameObject FindClosestPlayer()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("player");
        GameObject closestPlayer = null;
        float closestDistance = attackRange;

        foreach (GameObject player in players)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
            if (distanceToPlayer < closestDistance)
            {
                closestPlayer = player;
                closestDistance = distanceToPlayer;
            }
        }

        return closestPlayer;
    }

    public void SwitchBehavior(SCRIPTABLE_ShootBehavior newBehavior)
    {
        if (behaviors != null && behaviors.Contains(newBehavior))
        {
            // Cambiar al nuevo comportamiento si existe en la lista
            behaviors[0] = newBehavior;
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Dibuja el radio de ataque en la escena para visualizar el alcance
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
