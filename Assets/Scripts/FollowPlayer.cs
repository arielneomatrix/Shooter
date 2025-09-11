using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] Transform target;                 // arrastra aquí el Player (su Transform)
    [SerializeField] Vector3 offset = new Vector3(0, 10, -10);
    [SerializeField] float smooth = 10f;               // suavizado

    void LateUpdate()
    {
        if (!target) return;

        Vector3 desired = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desired, smooth * Time.deltaTime);

        // Si quieres que la cámara mire al jugador (opcional):
        // transform.LookAt(target);
    }
}
