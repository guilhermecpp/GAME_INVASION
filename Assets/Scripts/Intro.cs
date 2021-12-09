using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
  
  void Update()
  {

    if(Input.GetButtonDown("Easy") == true)
    {
      ItensPicker.difficulty = 0;
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    if(Input.GetButtonDown("Medium") == true)
    {
      ItensPicker.difficulty = 1;
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    if(Input.GetButtonDown("Hard") == true)
    {
      ItensPicker.difficulty = 2;
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

  }

}