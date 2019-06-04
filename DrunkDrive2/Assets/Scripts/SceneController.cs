using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadScene(int _index)
    {
        SceneManager.LoadScene(_index, LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}