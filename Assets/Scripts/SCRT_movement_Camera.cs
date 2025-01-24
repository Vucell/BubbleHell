using UnityEngine;

public class SCRT_movement_Camera : MonoBehaviour
{
    [Header("Follow Settings")]
    [Tooltip("El objeto que la c�mara seguir� (por ejemplo, el jugador).")]
    public Transform target;

    [Tooltip("Velocidad de seguimiento de la c�mara.")]
    public float followSpeed = 5f;

    private void LateUpdate()
    {
        // Si no hay un objetivo asignado, no hacemos nada.
        if (target == null) return;

        // Posici�n deseada es la posici�n del objetivo.
        Vector3 targetPosition = target.position;

        // Interpolamos la posici�n actual de la c�mara hacia la posici�n del objetivo.
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        // Actualizamos la posici�n de la c�mara.
        transform.position = new Vector3(smoothPosition.x, smoothPosition.y, transform.position.z);
    }
}
