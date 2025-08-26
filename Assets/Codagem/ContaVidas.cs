using UnityEngine;

public class ContaVidas : MonoBehaviour
{
    [SerializeField] private GameObject[] coracao;
    private PlayerMove player;
    void Start()
    {
        player = FindFirstObjectByType<PlayerMove>();
    }


    void Update()
    {

    }
    
    public void DestroiCoracao()
    {
        int vidaAtual = player.GetVida();
        if (vidaAtual >= 0 && vidaAtual < coracao.Length)
        {
            coracao[vidaAtual].SetActive(false);
        }
    }
}
