using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Balao : MonoBehaviour
{

  private Vector3 Diferenca;
  public Transform PosicaoPersonagem;
  public Transform PosicaoBalao;
  public Animator animator;
  public Transform forma;
  public Transform local;
  private int tempo = 20;
  private int tempo_sem_nada;

  void Start()
  {

    tempo = 20;
    tempo_sem_nada = 0;

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

    }

    Diferenca = PosicaoPersonagem.position * Vector2.right - PosicaoBalao.position * Vector2.right;

    if(Mathf.Abs(Vector3.Distance(Diferenca, Vector3.zero)) <= 0.5f && tempo_sem_nada == 0)
    {

      animator.SetBool("Atacar", true);

    }

    if(animator.GetBool("Atacar") == true)
    {

        tempo--;

        if(tempo == 0)
        {
          
          Instantiate(forma, local.position, local.rotation);
        
          tempo = 20;
          tempo_sem_nada = 100;
        
          animator.SetBool("Atacar", false);

        }

    }
    
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {

    if(collision.CompareTag("Peso") == true)//Essa condição verifica se o player encostou com um objeto com rotulo Fire
    {
      Destroy(collision.gameObject); //Destroi o fogo
      Destroy(gameObject); //Destroi o fogo
      ItensPicker.Itens--;
      ItensPicker.KillSoundReplay.volume = ((float)(15 - ItensPicker.Itens) / 15f);
      ItensPicker.KillSoundReplay.Play();
    }

  }

}