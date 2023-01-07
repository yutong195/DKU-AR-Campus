using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionBar : MonoBehaviour
{
    public static bool drawingOnSurface = false;
    public GameObject optionBar;
    
    public void DrawOnSurface()
    {
        drawingOnSurface = true;
        optionBar.SetActive(false);
    }

    public void DrawInSpace()
    {
        drawingOnSurface = false;
        optionBar.SetActive(false);
    }


   


}
