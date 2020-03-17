using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float smoothing;
    public Transform target;
    public Vector2 minPosition;
    public Vector2 maxPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {

        //transform.position = new Vector3(target.transform.position.x, target.transform.position.y,
           // transform.position.z);

        if(transform.position != target.position)
         {
          
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, -10);
           

            targetPosition.x = Mathf.Clamp(target.position.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(target.position.y, minPosition.y, maxPosition.y);

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);

            // transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        } 

     } 

    }

