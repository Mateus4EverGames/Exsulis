using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private float moveInput;
    private bool noChao = true;
    [SerializeField] private float velocidade;
    [SerializeField] private float forcaPulo;
    [SerializeField] private int vida;


    void Start()
    {
        velocidade = 5f;
        forcaPulo = 5f;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
        
           if (moveInput != 0f)
            {
                transform.localScale = new Vector3(Mathf.Sign(moveInput), 1f, 1f);
            }

            if(noChao && Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector2.up * forcaPulo, ForceMode2D.Impulse);
                noChao = false;
                //anim.SetBool
            }

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
           //     Ataque();
                //anim.SetBool
            }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput * velocidade, rb.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Chao"))
        {
            noChao = true;
        }
    }

    /*public void Ataque()
    {
        Collider2D[] inimigos = Physics2D.OverlapCircleAll(transform.position, 1f, LayerMask.GetMask("Inimigo"));
        foreach (Collider2D inimigoCol in inimigos)
        {
            Inimigos inimigo = inimigoCol.GetComponent<Inimigos>();
            if (inimigo != null)
            {
                inimigo.ReceberDano(dano);
            }
        }

    }*/
}