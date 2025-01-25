using System.Collections.Generic;
using UnityEngine;

public class SCRT_Atack_Player : MonoBehaviour
{
    //[Header("Attack Settings")]
    //[Tooltip("Radio de alcance para detectar enemigos.")]
    //public float attackRange = 5f;

    //[Tooltip("Tiempo entre disparos (en segundos).")]
    //public float timeBetweenShots = 1f;

    //[Tooltip("El prefab del proyectil que dispara el jugador.")]
    //public GameObject projectilePrefab;

    //[Tooltip("Punto desde el que se disparan los proyectiles.")]
    //public Transform firePoint;

    //private float shotTimer = 0f;

    //private void Update()
    //{
    //    // Incrementar el temporizador de disparo
    //    shotTimer += Time.deltaTime;

    //    // Detectar el enemigo más cercano dentro del radio
    //    GameObject closestEnemy = FindClosestEnemy();

    //    // Si hay un enemigo dentro del rango y podemos disparar
    //    if (closestEnemy != null && shotTimer >= timeBetweenShots)
    //    {
    //        // Disparar hacia el enemigo
    //        Shoot(closestEnemy.transform);
    //        shotTimer = 0f; // Reiniciar el temporizador
    //    }
    //}

    //private GameObject FindClosestEnemy()
    //{
    //    GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
    //    GameObject closestEnemy = null;
    //    float closestDistance = attackRange;

    //    foreach (GameObject enemy in enemies)
    //    {
    //        float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
    //        if (distanceToEnemy < closestDistance)
    //        {
    //            closestEnemy = enemy;
    //            closestDistance = distanceToEnemy;
    //        }
    //    }

    //    return closestEnemy;
    //}

    //private void Shoot(Transform target)
    //{
    //    if (projectilePrefab != null && firePoint != null)
    //    {
    //        // Crear el proyectil en la posición del firePoint
    //        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

    //        // Direccionar el proyectil hacia el enemigo
    //        Vector2 direction = (target.position - firePoint.position).normalized;
    //        projectile.GetComponent<SCRT_proyectile_Player>().SetDirection(direction);
    //    }
    //}

    //private void OnDrawGizmosSelected()
    //{
    //    // Dibuja el radio de ataque en la escena para visualizar el alcance
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(transform.position, attackRange);
    //}

    [Header("Attack Settings")]
    public float attackRange = 5f; // Radio de alcance
    public float timeBetweenShots = 1f; // Tiempo entre disparos
    public Transform firePoint; // Punto desde el que se disparan los proyectiles
    public GameObject projectilePrefab; // Prefab del proyectil

    public string objective;

    [Header("Behavior Settings")]
    public List<SCRIPTABLE_ShootBehavior> behaviors; // Lista de comportamientos
    private SCRIPTABLE_ShootBehavior currentBehavior; // Comportamiento actual

    private float shotTimer = 0f;

    private void Start()
    {
        // Seleccionar el primer comportamiento como predeterminado
        if (behaviors != null && behaviors.Count > 0)
        {
            currentBehavior = behaviors[0]; //Obsoleto
        }
    }

    private void Update()
    {
        // Incrementar el temporizador de disparo
        shotTimer += Time.deltaTime;

        // Buscar el enemigo más cercano dentro del rango
        GameObject closestEnemy = FindClosestEnemy();

        if (behaviors[0] != null && closestEnemy != null && shotTimer >= timeBetweenShots)
        {
            // Ejecutar el comportamiento actual
            //behaviors[0].ExecuteBehavior(this, closestEnemy.transform);
            for (int i = 0; i < behaviors.Count; i++) 
            {
                behaviors[i].ExecuteBehavior(this, closestEnemy.transform);

            }


            shotTimer = 0f; // Reiniciar el temporizador
        }
    }

    private GameObject FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(objective);
        GameObject closestEnemy = null;
        float closestDistance = attackRange;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < closestDistance)
            {
                closestEnemy = enemy;
                closestDistance = distanceToEnemy;
            }
        }

        return closestEnemy;
    }

    public void SwitchBehavior(SCRIPTABLE_ShootBehavior newBehavior)
    {
        currentBehavior = newBehavior;
    }

    private void OnDrawGizmosSelected()
    {
        // Dibuja el radio de ataque en la escena para visualizar el alcance
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

}
