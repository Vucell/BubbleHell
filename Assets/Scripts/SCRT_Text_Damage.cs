using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SCRT_Text_Damage : MonoBehaviour
{
    [Tooltip("El texto 3D que mostrar� el da�o.")]
    public TextMeshPro damageText;
     

    private float duration; // Duraci�n antes de desaparecer.
    private float speed;    // Velocidad de ascenso.

    public void Initialize(float damage, float duration, float speed)
    {
        this.duration = duration;
        this.speed = speed;

        // Configurar el texto con el da�o recibido.
        damageText.text = Mathf.RoundToInt(damage).ToString();

        // Comenzar la animaci�n.
        StartCoroutine(AnimateAndDestroy());
    }

    private System.Collections.IEnumerator AnimateAndDestroy()
    {
        // Elegir una direcci�n inicial aleatoria (izquierda o derecha).
        float horizontalOffset = Random.Range(-0.5f, 0.5f);

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            // Mover el texto hacia arriba con un ligero desplazamiento horizontal.
            transform.position += new Vector3(horizontalOffset, speed, 0) * Time.deltaTime;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Destruir el texto una vez finalizada la animaci�n.
        Destroy(gameObject);
    }
}
