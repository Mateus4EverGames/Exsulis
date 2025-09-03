using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private ContaVidas contaVidas;
    private Pause pausar;
    private float moveInput;
    private bool noChao = true;
    [SerializeField] private float velocidade;
    [SerializeField] private float forcaPulo;
    [SerializeField] private int vida;
    [SerializeField] private int dano = 1;
    public Pause puxaPause;


    void Start()
    {
        vida = 3;
        velocidade = 5f;
        forcaPulo = 5f;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        contaVidas = FindFirstObjectByType<ContaVidas>();
        pausar = FindFirstObjectByType<Pause>();
    }


    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");

        if (moveInput != 0f)
        {
            transform.localScale = new Vector3(Mathf.Sign(moveInput), 1f, 1f);
        }

        if (noChao && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * forcaPulo, ForceMode2D.Impulse);
            noChao = false;
            //anim.SetBool
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ataque();
            //anim.SetBool
        }
        if (vida == 0)
        {
            //puxaPause.GameOver();
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
        if (collision.gameObject.CompareTag("Queda"))
        {
            vida = 0;
            Destroy(gameObject);
            Time.timeScale = 0f;
           pausar.GameOver();
        }
    }

    public void Ataque()
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

    }

    public void ReceberDano(int dano)
    {
        vida -= dano;
        contaVidas.DestroiCoracao();
        if (vida <= 0)
        {
            //mortePainel.SetActive(true);
            Destroy(gameObject);
            Time.timeScale = 0f;

            //anim.SetTrigger("Morreu");
        }
    }

    public int GetVida()
    {
        return vida;
    }
}