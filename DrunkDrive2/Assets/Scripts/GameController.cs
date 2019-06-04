using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //Añadir funcionalidad para que al dar tap continue al siguiente juego en automatico
    public static GameController instance;
    private bool theGameIsOver = false;

    [SerializeField]
    private GameObject gameOverScreen;
    [SerializeField]
    private Text txt_gameOver;
    [SerializeField]
    private Color color;
    [SerializeField]
    private AudioSource audioSource;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
    }

    public void ResetGameController()
    {
        theGameIsOver = false;
        gameOverScreen.SetActive(false);
        txt_gameOver.text = "";
    }

    public bool GetGameIsOver()
    {
        return theGameIsOver;
    }

    public void WinGame()
    {
        theGameIsOver = true;
        gameOverScreen.SetActive(true);
        txt_gameOver.text = "You Win :D";
    }

    public void LoseGame()
    {
        theGameIsOver = true;
        gameOverScreen.SetActive(true);
        txt_gameOver.text = "You Lose :(";
    }
}