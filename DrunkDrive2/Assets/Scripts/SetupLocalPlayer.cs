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
        }
        else
        {
            GetComponent<Player>().enabled = false;
        }
    }

    // Update is called once per frame

    void Update()
    {
    }

}
