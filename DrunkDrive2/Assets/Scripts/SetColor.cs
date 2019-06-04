using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColor : MonoBehaviour
{
    [SerializeField]
    private Color color1;
    [SerializeField]
    private Color color2;
    [SerializeField]
    private Color color3;

    public void SetColor1()
    {
        GameController.instance.ChangeColor(color1);
    }

    public void SetColor2()
    {
        GameController.instance.ChangeColor(color2);
    }

    public void SetColor3()
    {
        GameController.instance.ChangeColor(color3);
    }
}
