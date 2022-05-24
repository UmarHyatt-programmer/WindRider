using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Loading : MonoBehaviour
{
    public Image bar;
    public float loadingTime;
    void Start()
    {
        Invoke("Delay", loadingTime);
    }
    void Update()
    {
      bar.fillAmount+=Time.deltaTime/loadingTime;
    }
    void Delay()
    {
        SceneManager.LoadScene(1);
    }
}
