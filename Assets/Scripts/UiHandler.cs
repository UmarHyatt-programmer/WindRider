using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiHandler : MonoBehaviour
{
   public void PlayGame()
   {

       //AdsManager.instance.ShowBanner();
       //AdsManager.instance.ShowIntersititial();
       SceneManager.LoadScene("Game Play");
   }
   public void QuitGame()
   {
       Debug.Log("Quitty");
    Application.Quit();
    }
}
