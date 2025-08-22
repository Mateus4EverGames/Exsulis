using UnityEngine;

public class CameraSegue : MonoBehaviour
{

    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset;

    void Start()
    {
        player  = FindFirstObjectByType<PlayerMove>().transform;
        offset = transform.position - player.position;
    }


    void Update()
    {
        
    }

    void LateUpdate()
    {
        transform.position = player.position + offset;
    }
}