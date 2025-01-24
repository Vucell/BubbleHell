using UnityEngine;

public class SCRT_movement_Camera : MonoBehaviour
{
    [Header("Follow Settings")]
    [Tooltip("El objeto que la cámara seguirá (por ejemplo, el jugador).")]
    public Transform target;

    [Tooltip("Velocidad de seguimiento de la cámara.")]
    public float followSpeed = 5f;

    private void LateUpdate()
    {
        // Si no hay un objetivo asignado, no hacemos nada.
        if (target == null) return;

        // Posición deseada es la posición del objetivo.
        Vector3 targetPosition = target.position;

        // Interpolamos la posición actual de la cámara hacia la posición del objetivo.
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        // Actualizamos la posición de la cámara.
        transform.position = new Vector3(smoothPosition.x, smoothPosition.y, transform.position.z);
    }
}
