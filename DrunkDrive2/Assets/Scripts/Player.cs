using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Player : MonoBehaviour
{
    public enum Direction
    {
        Right = 1,
        Left = -1
    }

    public enum GameState
    {
        Play,
        Win,
        Lose
    }

    [SerializeField]
    private CheckPointController mainCamera;

    [SerializeField]
    float RotationSpeed;
    [SerializeField]
    float MovementSpeed;

    [SerializeField]
    private GameObject Target;

    [SerializeField]
    private int numberOfCheckPoints;
    private List<CheckPointController> checkPoints = new List<CheckPointController>();

    Direction direction;
    GameState gameState;

    //sfx clips
    [SerializeField]
    private AudioSource chocar1;
    [SerializeField]
    private AudioSource chocar2;
    [SerializeField]
    private AudioSource derrape1;
    [SerializeField]
    private AudioSource aceleración;

    // Start is called before the first frame update
    void Start()
    {
        direction = Direction.Right;
        gameState = GameState.Play;
        if (GameController.instance)
            GameController.instance.ResetGameController();
    }

    // Update is called once per frame
    void Update()
    {
        var setupLocalPlayer = GetComponent<SetupLocalPlayer>();
        setupLocalPlayer.CmdCheckGameSatus();

        if (!GameController.instance || !GameController.instance.GetGameIsOver())
        {
            if (!aceleración.isPlaying)
                aceleración.Play();

            if (Input.GetMouseButtonDown(0))
            {
                if (Random.Range(0, 5) == 2)
                {
                    if (!derrape1.isPlaying)
                    {
                        derrape1.Play();
                    }
                }

                if (direction == Direction.Right)
                {
                    direction = Direction.Left;
                }
                else
                {
                    direction = Direction.Right;
                }
            }
            gameObject.transform.Translate(0, 0, MovementSpeed * Time.deltaTime);
            gameObject.transform.Rotate(0, (RotationSpeed * (int)direction) * Time.deltaTime, 0);
        }
        if (!setupLocalPlayer.youWin && gameState == GameState.Play)
        {
            if (checkPoints.Count >= numberOfCheckPoints)
            {
                Debug.Log("Win");
                gameState = GameState.Win;
                GameController.instance.WinGame();
                //setupLocalPlayer.CmdWin();
            }
        }
        else
        {
            if (gameState == GameState.Play)
            {
                Debug.Log("Lose");
                gameState = GameState.Lose;
                GameController.instance.LoseGame();
                //setupLocalPlayer.CmdLose();
            }
        }
    }

    public void SetMainCamera(CheckPointController _checkPointController)
    {
        mainCamera = _checkPointController;
    }

    public void AddCheckPoint(CheckPointController _checkPointController, AudioSource _checkPointSound)
    {
        if(!checkPoints.Contains(_checkPointController))
        {
            _checkPointSound.Play();
            checkPoints.Add(_checkPointController);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Road" || collision.gameObject.tag == "Player")
        {
            var randomFX = Random.Range(0, 3);

            switch(randomFX)
            {
                case 1:
                    if (!chocar1.isPlaying)
                        chocar1.Play();
                    break;
                case 2:
                    if (!chocar2.isPlaying)
                        chocar2.Play();
                    break;
                default:
                    if (!chocar1.isPlaying)
                        chocar1.Play();
                    break;
            }
        }
    }
}
