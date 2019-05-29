using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject target;

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, target.transform.position.z);
            //if(target.transform.rotation.eulerAngles.y > 45)
            //    transform.rotation.eulerAngles.Set(0, target.transform.rotation.y, 0);
        }
    }

    public void SetTarget(GameObject _target)
    {
        target = _target;
    }
}
