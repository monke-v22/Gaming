using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    public float CameraSpeed;
    public float minX,maxX;
    public float minY,maxY;
    private Camera Cam;
    public float TargetZoom =3;
    public float ZoomSpeed =3;
    private float ScrollData;
    void Start()
    {
        Cam = GetComponent<Camera>();
        TargetZoom = Cam.orthographicSize;
    }
    void FixedUpdate()
    {
        if(Target!= null)
        {
            Vector2 newCamPosition= Vector2.Lerp(transform.position, Target.position, Time.deltaTime*CameraSpeed);
            float ClampX = Mathf.Clamp(newCamPosition.x, minX, maxX);
            float ClampY = Mathf.Clamp(newCamPosition.y, minY, maxY);
            transform.position = new Vector3(ClampX, ClampY, -10f);
        } 

    }

    // Update is called once per frame
    void Update()
    {
        ScrollData = Input.GetAxis("Mouse ScrollWheel");
        TargetZoom = TargetZoom - ScrollData;
        TargetZoom = Mathf.Clamp(TargetZoom,3 ,6);
        Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, TargetZoom, Time.deltaTime * ZoomSpeed);
    }
}
