using System.Collections;
using UnityEngine;
using UnityEngine.UI;

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

    private void Start()
    {

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