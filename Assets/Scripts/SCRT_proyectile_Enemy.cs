using UnityEngine;
using UnityEngine.UI;

public class SCRT_proyectile_Enemy : MonoBehaviour
{
    [Tooltip("Velocidad del proyectil.")]
    public float speed = 10f;

    public float damage = 5f;

    public Vector2 direction;

    //public GameObject ExpSys;

    public void Start()
    {
        //ExpSys = GameObject.FindGameObjectWithTag("Text_EXP");

    }

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
    }

    private void Update()
    {
        // Mover el proyectil en la dirección asignada
        transform.Translate(direction * speed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("player"))
        {
            //ExpSys.GetComponent<SCRT_ExpSystem>().FinalGame();

            Destroy(collision.gameObject);
            Destroy(gameObject); // Destruir el proyectil.
        }
    }
}
