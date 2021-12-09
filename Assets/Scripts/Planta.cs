using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Planta : MonoBehaviour
{

  public Animator animator;
  public Transform PosicaoPersonagem;

  void Update()
  {
    if(Pause.pause == true)
    {
      animator.StartPlayback();
      return;
    }
		animator.StopPlayback();

      if(PlayerMovement.preso == true &&
         Mathf.Abs(Vector3.Distance(gameObject.transform.position, PosicaoPersonagem.position)) <= 3)
      {

        animator.SetBool("Atacar", true);

      }
    
  }

}