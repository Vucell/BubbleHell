using UnityEngine;

public class SCRT_ExplosionWave : MonoBehaviour
{
    public float maxRadius;
    public float duration;
    //public CircleCollider2D collider2D;
    public SpriteRenderer spriteRenderer;

    public void Initialize(float maxRadius, float duration)
    {
        this.maxRadius = maxRadius;
        this.duration = duration;

        //collider2D = GetComponent<CircleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        StartCoroutine(ExpandWave());
    }

    private System.Collections.IEnumerator ExpandWave()
    {
        float timer = 0f;
        Vector3 initialScale = Vector3.zero;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            float progress = timer / duration;

            // Expandir el tamaño del sprite y el collider
            float currentRadius = Mathf.Lerp(0f, maxRadius, progress);
            transform.localScale = new Vector3(currentRadius, currentRadius, 1f);

            //if (collider2D != null)
            //{
            //    collider2D.radius = currentRadius / 2f; // Ajustar radio del collider
            //}

            yield return null;
        }

        // Destruir la onda expansiva al finalizar
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verificar si el player está dentro de la onda
        if (collision.CompareTag("player"))
        {
            Destroy(collision.gameObject); // Destruir al jugador
        }
    }
}
