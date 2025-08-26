using UnityEngine;

public class CameraSegue : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float suavidade = 5f;
    [SerializeField] private float offsetY = 2f; 

    void Start()
    {
        player = FindFirstObjectByType<PlayerMove>().transform;
    }

    void LateUpdate()
    {
        Vector3 destino = new Vector3(
            player.position.x,
            player.position.y + offsetY, // Aplica o deslocamento para cima
            transform.position.z
        );
        transform.position = Vector3.Lerp(transform.position, destino, suavidade * Time.deltaTime);
    }
}