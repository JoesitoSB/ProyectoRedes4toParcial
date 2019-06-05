using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SetupLocalPlayer : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (isLocalPlayer)
        {
            var localPlayer = GetComponent<Player>();
            localPlayer.enabled = true;
            localPlayer.SetMainCamera(GameObject.Find("PlayerConfig").GetComponent<PlayerConfig>().mainCamera);
            localPlayer.SetNumberOfCheckpoints(GameObject.Find("PlayerConfig").GetComponent<PlayerConfig>().numberOfCheckPoints);
        }
        else
        {
            GetComponent<Player>().enabled = false;
        }
    }

    [SyncVar]
    public bool youWin;

    void Winner(bool _youwin)
    {
        youWin = _youwin;
    }

    [Command]
    public void CmdCheckGameSatus()
    {
         youWin = GameController.instance.theGameIsOver;
    }

    [Command]
    public void CmdWin()
    {
        youWin = true;
        GameController.instance.WinGame();
        GameController.instance.theGameIsOver = youWin;
    }

    [Command]
    public void CmdLose()
    {
        youWin = true;
        GameController.instance.LoseGame();
        GameController.instance.theGameIsOver = youWin;
    }

    // Update is called once per frame

    //void Update()
    //{
    //    CmdCheckWinner();
    //}

}
