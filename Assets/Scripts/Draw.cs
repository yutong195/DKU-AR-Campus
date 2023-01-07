using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.EventSystems;

public class Draw : MonoBehaviour
{
   
    public GameObject LineObject;
    public Camera TargetCamera;
    private LineRenderer line;
    public float DrawOffset;
    private int i;
    private bool DrawLine;
    //public float LineWidth;
    private GameObject clone;

    private ARRaycastManager rayManager;

    private static readonly List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Awake()
    {
        rayManager = FindObjectOfType<ARRaycastManager>(); 
    }


    // Start is called before the first frame update
    void Start()
    {
        DrawLine = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (!OptionBar.drawingOnSurface)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if(!IsPointOverUIObject(touch.position))
                {
                    switch (touch.phase)
                    {
                        // Record initial touch position.
                        case TouchPhase.Began:
                            clone = (GameObject)Instantiate(LineObject);
                            //clone.tag = "ARLines";
                            line = clone.GetComponent<LineRenderer>();
                            //line.startWidth = LineWidth;
                            //line.endWidth = LineWidth;
                            i = 0;
                            DrawLine = true;
                            break;
                        case TouchPhase.Moved:
                            break;
                        case TouchPhase.Ended:
                            i = 0;
                            DrawLine = false;
                            break;
                    }

                    if (DrawLine)
                    {
                        i++;
                        line.positionCount = i;
                        line.SetPosition(i - 1, TargetCamera.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, DrawOffset)));
                        
                        //line.SetPosition(i - 1, TargetCamera.transform.position + DrawOffset * TargetCamera.transform.forward);
                    }
                }
                
            }

        }

        else
        {
            if (Input.touchCount > 0)
            {

                Touch touch = Input.GetTouch(0);

                if(!IsPointOverUIObject(touch.position))
                {
                    var hits = new List<ARRaycastHit>();

                    bool hasHit = rayManager.Raycast(touch.position, hits, TrackableType.Planes);

                    if (hasHit && touch.phase == TouchPhase.Began)
                    {
                        clone = (GameObject)Instantiate(LineObject);
                        line = clone.GetComponent<LineRenderer>();
                        //line.startWidth = LineWidth;
                        //line.endWidth = LineWidth;
                        i = 0;
                        DrawLine = true;

                    }

                    else if (hasHit && touch.phase == TouchPhase.Moved)
                    {
                        DrawLine = true;
                    }

                    else if (hasHit && touch.phase == TouchPhase.Ended)
                    {
                        i = 0;
                        DrawLine = false;
                    }

                    if (DrawLine)
                    {
                        i++;
                        line.positionCount = i;
                        line.SetPosition(i - 1, hits[0].pose.position);
                        
                        //line.SetPosition(i - 1, TargetCamera.transform.position + DrawOffset * TargetCamera.transform.forward);
                    }
                }
                
            }
        }

    }


    bool IsPointOverUIObject(Vector2 pos)
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return false;

        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(pos.x, pos.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;

    }

    GameObject[] GetAllLinesInScene()
    {
        return GameObject.FindGameObjectsWithTag("Line");
    }

    public void Undo()
    {
        Debug.Log("Undo button pressed");

        GameObject[] linesInScene = GetAllLinesInScene();

        if (linesInScene.Length > 0)
            Destroy(linesInScene[linesInScene.Length - 1]);
    }

}
