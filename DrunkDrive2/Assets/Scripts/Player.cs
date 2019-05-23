using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum Direction
    {
        Right = 1,
        Left = -1
    }

    [SerializeField]
    float RotationSpeed;
    [SerializeField]
    float MovementSpeed;

    Direction direction;

    // Start is called before the first frame update
    void Start()
    {
        direction = Direction.Right;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(direction == Direction.Right)
            {
                direction = Direction.Left;
            }
            else
            {
                direction = Direction.Right;
            }
        }
        gameObject.transform.Translate(0, 0, -MovementSpeed * Time.deltaTime);
        gameObject.transform.Rotate(0, (RotationSpeed * (int) direction) * Time.deltaTime, 0);
    }
}
