using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float t;
    // Start is called before the first frame update
    void Start()
    {
        offset = -target.position + transform.position;
    }

    // Update is called once per frame
    public bool isSlerp;
    void LateUpdate()
    {
        transform.LookAt(target);
        if (isSlerp)
        {
            transform.position = Vector3.Slerp(transform.position, target.position + offset, t);
            return;
        }
            transform.position = Vector3.Lerp(transform.position,new Vector3(transform.position.x,transform.position.y,target.position.z+offset.z), t);
    }
    public Transform _target;
    private Vector3 velocity = Vector3.zero;
    public float smoothTime = 0.3F;

    // void Update()
    // {
    //     Vector3 targetPosition = _target.TransformPoint(new Vector3(0, -5, 2));
    //     transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    // }
}
