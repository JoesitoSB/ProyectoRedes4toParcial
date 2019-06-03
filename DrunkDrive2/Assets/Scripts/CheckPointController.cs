using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    [SerializeField]
    private Camera camera;
    [SerializeField]
    private CheckPointController lastCheckPointController;
    [SerializeField]
    private bool isTheMainCamera = false;

    // Start is called before the first frame update
    void Start()
    {
        if(!isTheMainCamera)
        {
            camera.gameObject.SetActive(false);
        }
        else
        {
            camera.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActiveCamera(bool _isActive)
    {
        camera.gameObject.SetActive(_isActive);
    }
}
