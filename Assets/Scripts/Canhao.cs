using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Canhao : MonoBehaviour
{
  private int tempo = -1;
  public Animator animator;
  private bool auxiliar = true;
  public Transform forma;
  public Transform local;
  public int tempo_sem_atirar = 100;

  void Update()
  {
    if(Pause.pause == true)
    {
      animator.StartPlayback();
      return;
    }
		animator.StopPlayback();

    if(tempo == -1)
    {

        tempo = tempo_sem_atirar;

        auxiliar = !auxiliar;
        
        animator.SetBool("Atacar", auxiliar);

        if(auxiliar == true)
        {
        
          tempo = 50;
        
        }

    }

    tempo--;

    if(auxiliar == true && tempo == 5)
    {

          Instantiate(forma, local.position, local.rotation);

    }
    
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {

    if(collision.CompareTag(forma.tag) == true)//Essa condição verifica se o player encostou com um objeto com rotulo Fire
    {
      Destroy(collision.gameObject); //Destroi o fogo
      Destroy(gameObject); //Destroi o fogo
      ItensPicker.Itens--;
      ItensPicker.KillSoundReplay.volume = ((float)(15 - ItensPicker.Itens) / 15f);
      ItensPicker.KillSoundReplay.Play();
    }

  }

}