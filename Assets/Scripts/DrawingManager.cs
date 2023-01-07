using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DrawingManager : MonoBehaviour
{
    public GameObject optionBar;
    // Start is called before the first frame update
    public void ShowOptionBar()
    {
        optionBar.SetActive(true);

    }
}
