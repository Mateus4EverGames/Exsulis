using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pauseGame;
    
    public void Start()
    {
        pauseGame.SetActive(false);
        
 
    }
    public void pause()
    {
        Time.timeScale = 0;
         pauseGame.SetActive(true);
    }
    public void Play()
    {
        Time.timeScale = 1;
         pauseGame.SetActive(false);
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
         Time.timeScale = 1;
    }
}