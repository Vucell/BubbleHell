using UnityEngine;

public class SCRT_movement_Player : MonoBehaviour
{
    [Header("Movement Settings")]
    [Tooltip("Velocidad máxima del jugador.")]
    public float moveSpeed = 5f;

    [Tooltip("Velocidad de desaceleración al soltar las teclas.")]
    public float decelerationSpeed = 10f;

    private Vector2 inputDirection; // Dirección del input del jugador.
    private Vector2 currentVelocity; // Velocidad actual del jugador.

    private void Update()
    {
        // Capturar el input del jugador (WASD o teclas de flechas).
        inputDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        // Si hay input, ajustamos la velocidad actual hacia la dirección deseada.
        if (inputDirection != Vector2.zero)
        {
            currentVelocity = Vector2.Lerp(currentVelocity, inputDirection * moveSpeed, Time.deltaTime * decelerationSpeed);
        }
        else
        {
            // Si no hay input, desaceleramos la velocidad gradualmente hacia cero.
            currentVelocity = Vector2.Lerp(currentVelocity, Vector2.zero, Time.deltaTime * decelerationSpeed);
        }

        // Aplicamos el movimiento al jugador.
        transform.Translate(currentVelocity * Time.deltaTime, Space.World);
    }
}
