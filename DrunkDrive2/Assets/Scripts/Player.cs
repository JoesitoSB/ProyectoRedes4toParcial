using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Networking;

public class Player : NetworkBehaviour
{
    public enum Direction
    {
        Right = 1,
        Left = -1
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

    // Start is called before the first frame update
    void Start()
    {
        direction = Direction.Right;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
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

        if (checkPoints.Count >= numberOfCheckPoints)
        {
            Debug.Log("Win");
        }
    }

    public void AddCheckPoint(CheckPointController _checkPointController)
    {
        if(!checkPoints.Contains(_checkPointController))
        {
            checkPoints.Add(_checkPointController);
        }
    }
}
