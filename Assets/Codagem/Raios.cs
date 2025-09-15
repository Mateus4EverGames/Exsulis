using UnityEngine;

public class Raios : MonoBehaviour
{
    [SerializeField] private float velocidade;
    [SerializeField] private float tempoDeRaio = 7.5f;
    [SerializeField] private int dano = 1;
    private float tempoDeVida;
    private Vector2 direcao;
    private PlayerMove player;

    void Start()
    {
        velocidade = 10f;
        player = FindFirstObjectByType<PlayerMove>();
        direcao = (player.transform.position - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {

            transform.position += (Vector3)direcao * velocidade * Time.deltaTime;
        }
        tempoDeVida += Time.deltaTime;
        if (tempoDeRaio <= tempoDeVida)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player != null)
            player.ReceberDano(dano);
            Destroy(gameObject);
        }
    }
}
