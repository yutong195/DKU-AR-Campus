using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReminderManager : MonoBehaviour
{

    public GameObject spaceReminder;
    public GameObject surfaceReminder;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OptionBar.drawingOnSurface)
        {
            spaceReminder.SetActive(false);
            surfaceReminder.SetActive(true);
        }
        if (!OptionBar.drawingOnSurface)
        {
            spaceReminder.SetActive(true);
            surfaceReminder.SetActive(false);
        }
    }
}
