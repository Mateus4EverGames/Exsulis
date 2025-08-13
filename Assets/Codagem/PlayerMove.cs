using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private float moveInput;
    [SerializeField] private float velocidade;
    [SerializeField] private float forcaPulo;
    [SerializeField] private int vida;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
