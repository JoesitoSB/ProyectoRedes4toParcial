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
    [SerializeField]
    private AudioSource checkPointSound;

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

    public Camera GetCamera()
    {
        return camera;
    }

    public void SetCamera(Camera _camera)
    {
        camera = _camera;
    }

    public CheckPointController GetLastCheckPointController()
    {
        return lastCheckPointController;
    }

    private void ActiveCamera(bool _isActive)
    {
        lastCheckPointController.GetCamera().gameObject.SetActive(!_isActive);
        camera.gameObject.SetActive(_isActive);
        //var auxCamera = lastCheckPointController.GetCamera();
        //lastCheckPointController.SetCamera(camera);
        //camera = auxCamera;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Paso el player");
            if(!camera.gameObject.activeInHierarchy)
            {
                Debug.Log("La camara no estaba activa");
                //ActiveCamera(true);
                camera.gameObject.SetActive(true);
                lastCheckPointController.GetCamera().gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("La camara si estaba activa");
                //ActiveCamera(false);
                camera.gameObject.SetActive(false);
                lastCheckPointController.GetCamera().gameObject.SetActive(true);
            }
            var player = other.GetComponent<Player>();
            player.AddCheckPoint(this, checkPointSound);
        }
    }
}
