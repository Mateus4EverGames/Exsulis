using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCreditos : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject canvaCreditos;
    public GameObject canvaMenu;
 
    public void Start()
    {
        canvaCreditos.SetActive(false);
        canvaMenu.SetActive(true);
 
    }
 
    public void Ativo()
    {
        canvaCreditos.SetActive(true);
        canvaMenu.SetActive(false);
    }
 
    public void Desativo()
    {
        canvaCreditos.SetActive(false);
        canvaMenu.SetActive(true);
    }
    public void IniciaJogo()
    {
        SceneManager.LoadScene("Tutorial");
         Time.timeScale = 1;
    }
    public void Quit()
{
    Application.Quit();
}
}
