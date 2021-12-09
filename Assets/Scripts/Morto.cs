using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Morto : MonoBehaviour
{

  public Vector3 PositionPersonagem_Y;
  private Vector3 PositionPause;

  private bool first = true;

  void Update()
  {

    if(Pause.pause == true)
    {

      if(first == true)
      {
        PositionPause = gameObject.transform.position;
        first = false;
      }

      gameObject.transform.position = PositionPause;
     
      return;
    }

    first = true;
    
    PositionPersonagem_Y = gameObject.transform.position;

		if(Mathf.Abs(PositionPersonagem_Y.y) > 20f)
		{
      SceneManager.LoadScene("GameOver");
		}
  }

}