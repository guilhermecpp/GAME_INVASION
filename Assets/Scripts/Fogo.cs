using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fogo : MonoBehaviour
{

  void Update()
  {
    
    if(Pause.pause == true)
    {
      return;
    }

    Destroy(gameObject, 5);

    transform.Translate(Vector2.right * (-1) * 3f * Time.deltaTime);
    
  }

}