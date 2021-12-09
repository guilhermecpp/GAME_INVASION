using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{

  void Update()
  {

    if(Input.GetButtonDown("Restart") == true)
    {
      SceneManager.LoadScene("Intro");
    }

  }

}