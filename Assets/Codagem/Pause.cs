using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pauseGame;
    public GameObject gameOver;
    public GameObject gameOver;
    
    public void Start()
    {
        pauseGame.SetActive(false);
        gameOver.SetActive(false);
        
 
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
    public void PlayGOver()
    {
        Time.timeScale = 1;
        gameOver.SetActive(false);
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
         Time.timeScale = 1;
    }
    public void GameOver()
    {
        gameOver.SetActive(true);
         Time.timeScale = 0;
    }
}