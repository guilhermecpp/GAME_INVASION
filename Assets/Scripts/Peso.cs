using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peso : MonoBehaviour
{
  
  void Update()
  {
    if(Pause.pause == true)
    {
      return;
    }

    Destroy(gameObject, 5);

    transform.Translate(Vector2.up * (-1) * 3f * Time.deltaTime);
    
  }

}