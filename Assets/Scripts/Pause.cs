using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
  
  public Transform CameraPosition;
  public static bool pause = false;

  void Update()
  {

    if(Input.GetButtonDown("Pause") == true)
    {
      pause = !pause;
    }

    gameObject.transform.position = CameraPosition.position - new Vector3(0, 0, CameraPosition.position.z);

    if(pause == false)
    {

      gameObject.transform.position -= new Vector3(0, 0, 20);

    }

  }

}