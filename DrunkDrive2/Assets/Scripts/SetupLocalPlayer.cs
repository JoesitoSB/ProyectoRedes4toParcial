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
            GetComponent<Player>().enabled = true;
        }
        else
        {
            GetComponent<Player>().enabled = false;
        }
    }

    [SyncVar(hook = "Winner")]
    private bool youWin;

    void Winner(bool _youwin)
    {
        youWin = _youwin;
    }

    [Command]
    public void CmdCheckWinner()
    {
         youWin = GameController.instance.theGameIsOver;
    }

    // Update is called once per frame

    void Update()
    {
        CmdCheckWinner();
    }

}
