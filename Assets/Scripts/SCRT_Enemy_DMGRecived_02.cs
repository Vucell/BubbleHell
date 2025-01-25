using UnityEngine;
using System.Collections.Generic;

public class SCRT_Enemy_DMGRecived_02 : MonoBehaviour
{
    [Header("Enemy Settings")]
    public float health = 100f;
    public GameObject damageTextPrefab;
    public float damageTextDuration = 1.5f;
    public float damageTextSpeed = 2f;

    [Header("Behavior Settings")]
    public List<SCRIPTABLE_EnemyBehavior> behaviors; // Lista de comportamientos
    public float movementSpeed = 2f;     // Velocidad base del enemigo
    private SCRIPTABLE_EnemyBehavior currentBehavior; // Comportamiento actual

    private void Start()
    {
        // Asegurarse de que hay al menos un comportamiento en la lista
        if (behaviors != null && behaviors.Count > 0)
        {
            currentBehavior = behaviors[0]; // Seleccionar el primer comportamiento como predeterminado
        }
    }

    private void Update()
    {
        if (currentBehavior != null)
        {
            // Ejecutar el comportamiento actual
            currentBehavior.ExecuteBehavior(this);
        }
    }

    public void SwitchBehavior(SCRIPTABLE_EnemyBehavior newBehavior)
    {
        currentBehavior = newBehavior;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            Debug.Log("Jugador muerto");
            Destroy(collision.gameObject); // Destruir el jugador
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        ShowDamageText(damage);

        if (health <= 0)
        {
            Die();
        }
    }

    private void ShowDamageText(float damage)
    {
        if (damageTextPrefab != null)
        {
            GameObject damageText = Instantiate(damageTextPrefab, transform.position, Quaternion.identity);
            SCRT_Text_Damage damageTextScript = damageText.GetComponent<SCRT_Text_Damage>();
            damageTextScript.Initialize(damage, damageTextDuration, damageTextSpeed);
        }
    }

    private void Die()
    {
        Debug.Log("Enemigo muerto");
        Destroy(gameObject);
    }
}
