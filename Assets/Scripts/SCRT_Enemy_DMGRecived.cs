using System;
using UnityEngine;

public class SCRT_Enemy_DMGRecived : MonoBehaviour
{
    [Header("Enemy Settings")]
    [Tooltip("Cantidad de vida del enemigo.")]
    public float health = 100f;

    [Tooltip("Prefab del texto de daño que se mostrará al recibir un impacto.")]
    public GameObject damageTextPrefab;

    [Tooltip("El tiempo que tarda el texto de daño en desaparecer.")]
    public float damageTextDuration = 1.5f;

    [Tooltip("Velocidad de ascenso del texto de daño.")]
    public float damageTextSpeed = 2f;

    public void TakeDamage(float damage)
    {
        // Reducir la vida del enemigo.
        health -= damage;

        // Mostrar el texto de daño.
        ShowDamageText(damage);

        // Verificar si el enemigo debe morir.
        if (health <= 0)
        {
            Die();
        }
    }

    private void ShowDamageText(float damage)
    {
        if (damageTextPrefab != null)
        {
            // Crear el texto de daño en la posición del enemigo.
            GameObject damageText = Instantiate(damageTextPrefab, transform.position, Quaternion.identity);

            // Configurar el texto de daño.
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
