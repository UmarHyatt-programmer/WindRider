using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    public static WheelController instance;
    public List<Transform> pickedObjects=new List<Transform>();
    //public Transform[] pickObjects;
    // Start is called before the first frame update

    public float radius;
    public float verticalMovement;
    public int currentObject = 0;
    public Rigidbody rb;
    public int movingSpeed, verticalSpeed;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        pickedObjects.Add(transform);
        radius = transform.localScale.z + 0.1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity=Vector3.forward*movingSpeed*Time.deltaTime;
        //transform.Translate(Vector3.forward*movingSpeed*Time.deltaTime);
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-Vector3.right*verticalSpeed*Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right*verticalSpeed*Time.deltaTime);
        }
    }
    private void OnCollisionEnter(Collision collisionObj)
    {
        if (collisionObj.transform.tag == "Object")
        {
            //pickedObjects.Add(collisionObj.transform);
            currentObject++;
           // collisionObj.transform.GetComponent<Object>().offSet=currentObject;
            //collisionObj.transform.parent=transform;
            //collisionObj.transform.SetParent(null,false);
           // collisionObj.gameObject.GetComponent<Object>().target = transform;
            // transform.SetParent(target);
        }
    }
}
