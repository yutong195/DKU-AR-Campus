using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scan : MonoBehaviour
{
    public void WelcomeToCamera(string Camera)
    {
        SceneManager.LoadScene(Camera);
       
    }
}
