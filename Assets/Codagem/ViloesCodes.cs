using UnityEngine;

public class ViloesCodes : MonoBehaviour
{
    // Configurações do chefe
    [SerializeField] private int vida;
    [SerializeField] private float velocidade;
    [SerializeField] private GameObject raioPrefab;
    [SerializeField] private Transform pontoDeLancamento;
    [SerializeField] private float intervaloAtaque;
    [SerializeField] private float tempoVoando;
    [SerializeField] private float tempoChao;
    [SerializeField] private float tempoCaindo;
    [SerializeField] private float detectaDistancia;
    [SerializeField] private AudioClip vitoria;
    // Componentes
    private AudioSource audioZeus;
    private Animator anim;
    private Rigidbody2D rb;
    private Transform player;

    // Controle de estados
    private enum Estado { Voando, Atacando, Caindo, Chao }
    private Estado estadoAtual = Estado.Voando;

    // Timers e contadores
    private float timerEstado;
    private int raiosLançados;
    private float timerAtaque;

    void Start()
    {
        // Valores padrão do chefe
        vida = 12;
        velocidade = 2f;
        intervaloAtaque = 1f;
        tempoVoando = 3f;
        tempoChao = 4f;
        tempoCaindo = 3f;
        detectaDistancia = 8f;

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        player = FindFirstObjectByType<PlayerMove>().transform;

        estadoAtual = Estado.Voando;
        timerEstado = 0f;
        raiosLançados = 0;
        timerAtaque = 0f;
    }

    void Update()
    {
        float distanciaPlayer = Vector2.Distance(transform.position, player.position);

        switch (estadoAtual)
        {
            case Estado.Voando:
                timerEstado += Time.deltaTime;
                rb.velocity = new Vector2(0, velocidade);

                if (timerEstado >= tempoVoando)
                {
                    estadoAtual = Estado.Atacando;
                    anim.SetBool("IsVoando", true);
                    timerEstado = 0f;
                    raiosLançados = 0;
                    timerAtaque = 0f;
                    rb.velocity = Vector2.zero;
                }
                /*else
                {
                    rb.velocity = Vector2.zero;
                }*/
                break;

            case Estado.Atacando:
                if (distanciaPlayer <= detectaDistancia)
                {
                    timerAtaque += Time.deltaTime;

                    if (raiosLançados < 3 && timerAtaque >= intervaloAtaque)
                    {
                        LancaRaio();
                        raiosLançados++;
                        timerAtaque = 0f;
                    }

                    if (raiosLançados >= 3)
                    {
                        estadoAtual = Estado.Caindo;
                        timerEstado = 0f;
                    }
                }
                break;

            case Estado.Caindo:
                timerEstado += Time.deltaTime;
                rb.velocity = new Vector2(0, -velocidade);

                if (timerEstado >= tempoCaindo)
                {
                    estadoAtual = Estado.Chao;
                    timerEstado = 0f;
                    rb.velocity = Vector2.zero;
                }
                break;

            case Estado.Chao:
                timerEstado += Time.deltaTime;

                if (timerEstado >= tempoChao)
                {
                    anim.SetBool("IsVoando", false);
                    anim.SetBool("IsAtacando", false);
                    estadoAtual = Estado.Voando;
                    timerEstado = 0f;
                }
                break;
        }
    }

    // Instancia o raio no ponto de lançamento
    void LancaRaio()
    {
        Instantiate(raioPrefab, pontoDeLancamento.position, Quaternion.identity);
        anim.SetBool("IsAtacando", true);
    }

    // Recebe dano do player
    public void ReceberDano(int dano)
    {
        vida -= dano;
        if (vida <= 0)
        {
            Destroy(gameObject);
            audioZeus.PlayOneShot(vitoria);
            //pausar.Vitoria();
            //anim.SetTrigger("Morreu");
        }
    }
}
