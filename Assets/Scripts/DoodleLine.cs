using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoodleLine : MonoBehaviour
{
    public delegate bool RaycastDelegate(out Vector3 hitPosition);

    public RaycastDelegate raycastDelegate = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
