using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class EnemyManager : MonoBehaviour
{
    [Header("Timer Settings")]
    public Text timerText; // Texto en el Canvas para mostrar el temporizador
    public bool infiniteMode = false; // Activar o desactivar el modo infinito
    private float roundTime; // Tiempo actual de la ronda
    private int currentRound = 1; // Ronda actual
    private bool isInfinite = false; // Indica si el modo infinito está activo

    [Header("Experience Settings")]
    public SCRT_ExpSystem expSystem; // Referencia al sistema de experiencia
    public float baseExp = 10f; // Experiencia base otorgada por enemigo

    [Header("Spawn Settings")]
    public List<Transform> spawnCercanos; // Puntos de spawn cercanos
    public List<Transform> spawnLejanos; // Puntos de spawn lejanos
    public List<GameObject> enemyPrefabs; // Prefabs de enemigos
    public float spawnInterval = 0.5f; // Tiempo base entre spawns
    public float spawnIntervalIncreasePerRound = 0.05f; // Incremento del tiempo entre spawns por ronda
    public int maxEnemiesPerRound = 10; // Número máximo de enemigos por ronda
    public int maxEnemiesIncreasePerRound = 5; // Incremento de enemigos máximos por ronda

    [Header("Enemy Settings")]
    public int healthIncreasePerRound = 20; // Incremento de vida por ronda
    public int healthIncreaseInfinite = 30; // Incremento de vida cada 2 minutos en modo infinito

    [Header("Round Durations")]
    public float[] roundDurations = { 90f, 120f, 90f }; // Duración de las rondas (en segundos)

    private List<GameObject> activeEnemies = new List<GameObject>(); // Lista de enemigos activos
    private Coroutine spawnRoutine; // Rutina de spawn de enemigos
    private int enemiesSpawnedInRound = 0; // Número de enemigos spawneados en la ronda actual

    private void Start()
    {
        StartRound(currentRound);
    }

    private void Update()
    {
        if (!isInfinite)
        {
            // Reducir el temporizador durante las rondas normales
            roundTime -= Time.deltaTime;
            UpdateTimerUI();

            if (roundTime <= 0)
            {
                EndRound();
            }
        }
        else
        {
            // Actualizar temporizador progresivo en modo infinito
            roundTime += Time.deltaTime;
            UpdateTimerUI();
        }
    }

    private void StartRound(int round)
    {
        roundTime = roundDurations[Mathf.Clamp(round - 1, 0, roundDurations.Length - 1)];
        ClearEnemies();

        enemiesSpawnedInRound = 0; // Reiniciar el contador de enemigos spawneados
        maxEnemiesPerRound += maxEnemiesIncreasePerRound * (round - 1); // Incrementar el límite de enemigos

        spawnInterval += spawnIntervalIncreasePerRound * (round - 1); // Incrementar el tiempo de aparición entre enemigos

        if (spawnRoutine != null)
            StopCoroutine(spawnRoutine);

        spawnRoutine = StartCoroutine(SpawnEnemies(round));
    }

    private void EndRound()
    {
        if (currentRound < 3)
        {
            currentRound++;
            StartRound(currentRound);
        }
        else
        {
            if (infiniteMode)
            {
                isInfinite = true;
                if (spawnRoutine != null)
                    StopCoroutine(spawnRoutine);

                spawnRoutine = StartCoroutine(SpawnEnemiesInfinite());
            }
            else
            {
                SceneManager.LoadScene("MainMenu"); // Cambiar a la escena del menú
            }
        }
    }

    private IEnumerator SpawnEnemies(int round)
    {
        List<Transform> spawnPoints = round >= 3 ? spawnCercanos.Concat(spawnLejanos).ToList() : spawnCercanos;

        while (enemiesSpawnedInRound < maxEnemiesPerRound)
        {
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
            GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];

            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
            activeEnemies.Add(enemy);
            enemiesSpawnedInRound++;

            // Ajustar vida del enemigo según la ronda
            SCRT_Enemy_DMGRecived_02 enemyScript = enemy.GetComponent<SCRT_Enemy_DMGRecived_02>();
            if (enemyScript != null)
            {
                enemyScript.health += healthIncreasePerRound * (round - 1);

                // Suscribirse al evento OnDeath para otorgar experiencia
                //enemyScript.OnDeath += () =>
                //{
                //    //float expGranted = baseExp * currentRound; // Incrementar experiencia por ronda
                //    expSystem.AddExperience(baseExp); // Añadir experiencia al sistema
                //};
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private IEnumerator SpawnEnemiesInfinite()
    {
        List<Transform> spawnPoints = spawnCercanos.Concat(spawnLejanos).ToList();
        float infiniteHealthIncrease = healthIncreasePerRound * 3; // Incremento base en modo infinito

        while (true)
        {
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
            GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];

            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
            activeEnemies.Add(enemy);

            // Ajustar vida del enemigo en modo infinito
            SCRT_Enemy_DMGRecived_02 enemyScript = enemy.GetComponent<SCRT_Enemy_DMGRecived_02>();
            if (enemyScript != null)
            {
                enemyScript.health += (int)infiniteHealthIncrease;

                // Suscribirse al evento OnDeath para otorgar experiencia
                //enemyScript.OnDeath += () =>
                //{
                //    //float expGranted = baseExp * currentRound; // Incrementar experiencia por ronda
                //    expSystem.AddExperience(baseExp); // Añadir experiencia al sistema
                //};
            }

            yield return new WaitForSeconds(spawnInterval);

            // Aumentar la dificultad cada 2 minutos
            if ((int)roundTime % 120 == 0)
            {
                infiniteHealthIncrease += healthIncreaseInfinite;
                spawnInterval = Mathf.Max(0.2f, spawnInterval - 0.1f); // Reducir intervalo mínimo a 0.2 segundos
            }
        }
    }


    private void ClearEnemies()
    {
        foreach (var enemy in activeEnemies)
        {
            if (enemy != null)
                Destroy(enemy);
        }
        activeEnemies.Clear();
        enemiesSpawnedInRound = 0; // Reiniciar el contador al limpiar enemigos
    }

    private void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(roundTime / 60f);
        int seconds = Mathf.FloorToInt(roundTime % 60f);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }

}
