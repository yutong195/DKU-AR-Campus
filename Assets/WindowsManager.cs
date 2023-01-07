using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsManager : MonoBehaviour
{
    [SerializeField]
    GameObject askNewDocument;
    [SerializeField] Transform canvasTransform;

    GameObject SpawnInCanvas(GameObject go)
    {
        return Instantiate(go, canvasTransform);
    }

    public void SpawnAskToRestartDocument()
    {
        SpawnInCanvas(askNewDocument);
    }
}
