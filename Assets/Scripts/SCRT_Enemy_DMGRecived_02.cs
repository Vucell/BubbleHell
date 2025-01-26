using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Experimental.Rendering;

public class SCRT_Enemy_DMGRecived_02 : MonoBehaviour
{
    [Header("Enemy Settings")]
    public float health = 100f;
    public GameObject damageTextPrefab;
    public float damageTextDuration = 1.5f;
    public float damageTextSpeed = 2f;

    public int INT_Score;
    public GameObject TXT_Score;
    public GameObject ExpSys;
    public float baseExp = 10f; // Experiencia base otorgada por enemigo

    [Header("Behavior Settings")]
    public List<SCRIPTABLE_EnemyBehavior> behaviors; // Lista de comportamientos
    //public float movementSpeed = 2f;     // Velocidad base del enemigo
    private SCRIPTABLE_EnemyBehavior currentBehavior; // Comportamiento actual

    private void Start()
    {
        // Asegurarse de que hay al menos un comportamiento en la lista
        if (behaviors != null && behaviors.Count > 0)
        {
            currentBehavior = behaviors[0]; // Seleccionar el primer comportamiento como predeterminado
        }
        TXT_Score = GameObject.FindGameObjectWithTag("Text_Score");
        ExpSys = GameObject.FindGameObjectWithTag("Text_EXP");
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
    
    public event System.Action OnDeath;
    public void TakeDamage(float damage)
    {
        health -= damage;
        ShowDamageText(damage);

        if (health <= 0)
        {
            OnDeath?.Invoke();
            
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


    public void newScore()
    {
        //ExpSys.INT_TOTAL_Score = ExpSys.INT_TOTAL_Score + INT_Score;
        ExpSys.GetComponent<SCRT_ExpSystem>().INT_TOTAL_Score = ExpSys.GetComponent<SCRT_ExpSystem>().INT_TOTAL_Score + INT_Score;
        //TXT_Score.text = "SCORE: " + ExpSys.INT_TOTAL_Score.ToString();
        TXT_Score.GetComponent<Text>().text = "SCORE: " + ExpSys.GetComponent<SCRT_ExpSystem>().INT_TOTAL_Score.ToString();
    }


    private void Die()
    {

        ExpSys.GetComponent<SCRT_ExpSystem>().AddExperience(baseExp);
        newScore();

        Debug.Log("Enemigo muerto");
        Destroy(gameObject);
    }
}
