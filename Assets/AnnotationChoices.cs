using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnnotationChoices : MonoBehaviour
{
    public GameObject annotationChoices;
    // Start is called before the first frame update
    public void OnClickAnnotation()
    {
        if(!annotationChoices.activeInHierarchy)
        {
            annotationChoices.SetActive(true);
        }

        else
        {
            annotationChoices.SetActive(false);
        }
    }
}
