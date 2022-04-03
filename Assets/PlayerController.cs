using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rigidbody;
    public Vector3 forwardSpeed;
    public bool moveWithPhy;
    void Update()
    {
        MobileController();
    }
    void FixedUpdate()
    {
        if (moveWithPhy)
            rigidbody.velocity = forwardSpeed*30;
    }
    Touch touch;
    public float sensitivity = 0.5f;
    public float maxHight, minHight, maxRight, minRight;
    public void MobileController()
    {
        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Moved)
            {
                forwardSpeed = new Vector3(Mathf.Clamp(t.deltaPosition.x, minRight, maxRight) * sensitivity * Time.deltaTime, Mathf.Clamp(t.deltaPosition.y, minHight, maxHight) * sensitivity * Time.deltaTime, forwardSpeed.z);
            }
        }
        if(moveWithPhy)return;
        transform.localPosition += forwardSpeed;
    }
}
