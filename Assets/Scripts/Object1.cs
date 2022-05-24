using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object1 : MonoBehaviour
{
    public Rigidbody rb;
   public float movingSpeed , verticalSpeed ;
    //  public float movingSpeed = WheelController1.instance.movingSpeed, verticalSpeed = WheelController1.instance.verticalSpeed;
    public float verticalTime ;

    public float lerpT;
    public Transform target;
    public float offSet;
    //public int x;
    void Update()
    {  if( transform.tag == "Player"){
        rb.velocity = Vector3.forward * movingSpeed * Time.deltaTime;
        //transform.Translate(Vector3.forward*movingSpeed*Time.deltaTime);
        if (Input.GetKey(KeyCode.A))
        {
            Invoke("LeftController", verticalTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Invoke("RightController", verticalTime);
        }
        }
    }
    public void LeftController()
    {
        transform.Translate(-Vector3.right * verticalSpeed * Time.deltaTime);
    }
    public void RightController()
    {
        transform.Translate(Vector3.right * verticalSpeed * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player")
        {
            if (transform.tag == "Object")
            {
                WheelController.instance.pickedObjects.Add(transform);
                print(other.gameObject.name);
                transform.tag = other.transform.tag;
            }
            if (target == null)
            {
                target = WheelController.instance.pickedObjects[WheelController.instance.pickedObjects.Count - 2];
            }
        }
    }
    // public Vector3 velocity=Vector3.zero;
    // public float smoothTime,maxSpeed,deltaTime;
    public bool isLerp;
    public float moveT;
    private void LateUpdate()
    {
        // if (target != null)
        // {
        //     if (isLerp)
        //     {
        //         transform.position = new Vector3(transform.position.x, transform.position.y, target.position.z + 1 + WheelController.instance.radius * offSet);
        //         transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, transform.position.y, transform.position.z), lerpT * Time.deltaTime);
        //         return;
        //     }
        //     transform.position = new Vector3(Mathf.Lerp(transform.position.x, target.position.x, lerpT * Time.deltaTime), transform.position.y, target.position.z + 1 + 0.5f * offSet);
        //     //transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x, transform.position.y, transform.position.z), moveT*Time.deltaTime);
        //     //transform.position = new Vector3(transform.position.x, transform.position.y, target.position.z + 1 + WheelController.instance.radius * offSet);
        //     // transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x, transform.position.y, transform.position.z), lerpT);
        //     // transform.position = Vector3.SmoothDamp(transform.position, new Vector3(target.position.x, transform.position.y, transform.position.z),ref velocity,smoothTime,maxSpeed,deltaTime);
        // }
    }
}
