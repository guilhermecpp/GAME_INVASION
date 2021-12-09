using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Slime : MonoBehaviour
{
  private int tempo = -1;
  public int distancia_inicial = 30;
  public int distancia = 0;
  public float velocity = 0;
  public Animator animator;
  private bool auxiliar = false;
  public Transform forma;
  public Transform local;
  private int tempo_sem_nada;
  public int tempo_sem_atirar;

  void Start()
  {

    tempo_sem_nada = 0;
    distancia = distancia_inicial;

  }

  void Update()
  {
    if(Pause.pause == true)
    {
      animator.StartPlayback();
      return;
    }
		animator.StopPlayback();

    if(tempo_sem_nada != 0)
    {

      tempo_sem_nada--;

    }else
    {
        

      if(tempo == -1)
      {

          //tempo = 217;
          
          tempo = tempo_sem_atirar;

          if(auxiliar == true)
          {
            tempo = 10;
          }

      }

      tempo--;

      if(tempo == 0)
      {

          auxiliar = !auxiliar;

          if(auxiliar == false)
          {
            
            Instantiate(forma, local.position, local.rotation);

            tempo_sem_nada = 50;

          }

          animator.SetBool("Atacar", auxiliar);

          tempo--;
          
      }

      if(auxiliar == false)
      {

        if(distancia == 0)
        {

          transform.right = transform.right * Vector2.right * -1;

          distancia = distancia_inicial;

        }else
        {

          if(distancia >= 0)
          {
            distancia--;
          }

        }
            transform.Translate(Vector2.right * (-1) * velocity * Time.deltaTime);

      }

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