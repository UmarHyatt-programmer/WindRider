using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public float lerpT;
    public Transform target;
    public float offSet;
    //public int x;
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
               // StartLerp();
            }
        }
    }
   // public Vector3 velocity=Vector3.zero;
   // public float smoothTime,maxSpeed,deltaTime;
   public bool isLerp;
   public float moveT;
    private void Update()
    {
        if (target != null)
        {
            if(isLerp)
            {
            transform.position = new Vector3(transform.position.x, transform.position.y, target.position.z + 1 + WheelController.instance.radius * offSet);
            transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, transform.position.y, transform.position.z), lerpT*Time.deltaTime);
            return;
            }
            transform.Translate(new Vector3(Mathf.Lerp(transform.position.x,target.position.x,lerpT*Time.deltaTime), transform.position.y, target.position.z + 1 + 0.5f * offSet));
            //transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x, transform.position.y, transform.position.z), moveT*Time.deltaTime);
            //transform.position = new Vector3(transform.position.x, transform.position.y, target.position.z + 1 + WheelController.instance.radius * offSet);
           // transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x, transform.position.y, transform.position.z), lerpT);
           // transform.position = Vector3.SmoothDamp(transform.position, new Vector3(target.position.x, transform.position.y, transform.position.z),ref velocity,smoothTime,maxSpeed,deltaTime);
        }
    }
public float targetValue,duration;
void StartLerp()
{
  StartCoroutine(LerpFunction(duration));
}
IEnumerator LerpFunction(float duration)
{
  float time = 0;
  while (true)
  {
    transform.position = new Vector3(Mathf.Lerp(transform.position.x,target.position.x,time/duration), transform.position.y, target.position.z + 1 + 0.5f * offSet);
    time += Time.deltaTime;
    yield return null;
  }
}
}
