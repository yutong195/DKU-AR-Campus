using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageFlip : MonoBehaviour
{
    public GameObject page1;
    public GameObject page2;

    public void Page1toPage2()
    {
        page1.SetActive(false);
        page2.SetActive(true);
    }

    public void Page2toPage1()
    {
        page1.SetActive(true);
        page2.SetActive(false);
    }
}
