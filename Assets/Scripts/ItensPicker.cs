using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Bibliotecas
public class ItensPicker : MonoBehaviour { // Nome da Classe

    public AudioSource HitSound;
    public AudioSource KillSound;
    public static AudioSource KillSoundReplay; 
    public static int Itens; //Conta o numero de moedas
    public Text scoreText; //Pontuação
    public Text liveText; // Vida
    public Text timeText; // Vida
    public static int live; // barra de vida
    public static int difficulty;
    public static int timeLeft;
    private int aux;
    
    private void Start()
    {

        //inicializa variaveis 
        Itens = 15;
        scoreText.text = "";
        liveText.text = "";
        timeText.text = "";

        
        if(difficulty == 1)
        {
          live = 10;
        }
        
        if(difficulty == 2)
        {
          live = 5;
        }
        
        if(difficulty == 3)
        {
          live = 1;
        }

        if(difficulty == 4)
        {
          timeLeft = 60;
          live = 1;
          aux = 50;
        }


        KillSoundReplay = KillSound;

    }

    private void Update()
    {

      scoreText.text = "Enemies: "+Itens.ToString();
      liveText.text = "Lifes: "+live.ToString();

      if(difficulty == 4 && Pause.pause == false && SceneManager.GetActiveScene().name == "Fase02")
      {
    
        timeText.text = timeLeft.ToString();        

        if(aux == 0)
        {

          timeLeft--;

          aux = 50;

        }else
        {

          aux--;

        }

        if(timeLeft == 0)
        {

          live = 0;

        }

      }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.CompareTag("Inimigo") == true)//Essa condição verifica se o player encostou com um objeto com rotulo Fire
        {
          live -= 1; //Decrementa a vida   
          HitSound.Play();
        }

        if(collision.CompareTag("Fogo") == true)//Essa condição verifica se o player encostou com um objeto com rotulo Fire
        {
            if(PlayerMovement.escudo == false)
            {
              live -= 1; //Decrementa a vida
              HitSound.Play();
              Destroy(collision.gameObject); //Destroi o fogo
            } else
            {
              collision.gameObject.transform.right = Vector2.right * -1;
            }
        }

        
        if(collision.CompareTag("Fogo2") == true)//Essa condição verifica se o player encostou com um objeto com rotulo Fire
        {
            if(PlayerMovement.escudo == false)
            {
              live -= 1; //Decrementa a vida
              HitSound.Play();
              Destroy(collision.gameObject); //Destroi o fogo
            } else
            {
              collision.gameObject.transform.right = Vector2.right * -1;
            }
        }

        
        if(collision.CompareTag("Fogo3") == true)//Essa condição verifica se o player encostou com um objeto com rotulo Fire
        {
            if(PlayerMovement.escudo == false)
            {
              live -= 1; //Decrementa a vida
              HitSound.Play();
              Destroy(collision.gameObject); //Destroi o fogo
            } else
            {
              collision.gameObject.transform.right = Vector2.right * -1;
            }
        }
        
        if(collision.CompareTag("Bola") == true)//Essa condição verifica se o player encostou com um objeto com rotulo Fire
        {
            if(PlayerMovement.escudo == false)
            {
              live -= 1; //Decrementa a vida
              HitSound.Play();
              Destroy(collision.gameObject); //Destroi o fogo
            } else
            {
              collision.gameObject.transform.right = Vector2.right * -1;
            }
        }
        
        if(collision.CompareTag("Bola2") == true)//Essa condição verifica se o player encostou com um objeto com rotulo Fire
        {
            if(PlayerMovement.escudo == false)
            {
              live -= 1; //Decrementa a vida
              HitSound.Play();
              Destroy(collision.gameObject); //Destroi o fogo
            } else
            {
              collision.gameObject.transform.right = Vector2.right * -1;
            }
        }
        
        if(collision.CompareTag("Bola3") == true)//Essa condição verifica se o player encostou com um objeto com rotulo Fire
        {
            if(PlayerMovement.escudo == false)
            {
              live -= 1; //Decrementa a vida
              HitSound.Play();
              Destroy(collision.gameObject); //Destroi o fogo
            } else
            {
              collision.gameObject.transform.right = Vector2.right * -1;
            }
        }

        if(collision.CompareTag("Peso") == true)//Essa condição verifica se o player encostou com um objeto com rotulo Fire
        {
            if(PlayerMovement.escudo == false)
            {
              live -= 1; //Decrementa a vida
              HitSound.Play();
              Destroy(collision.gameObject); //Destroi o fogo
            } else
            {
              collision.gameObject.transform.up = Vector2.up * -1;
            }
        }

        if(collision.CompareTag("Planta") == true)//Essa condição verifica se o player encostou com um objeto com rotulo Fire
        {
            if(PlayerMovement.escudo == false)
            {
              live -= 1; //Decrementa a vida
              HitSound.Play();
              CharacterController2D.m_Rigidbody2D.gravityScale = 0;
              PlayerMovement.preso = true;
              PlayerMovement.LocalPreso = collision.gameObject.transform.position + new Vector3(-0.1f, 1.5f, 0);
            } else
            {
              Destroy(collision.gameObject);
              ItensPicker.Itens--;
              KillSound.volume = ((float)(15 - Itens) / 15f);
              KillSound.Play();
            }
        }
        
        if(collision.CompareTag("Fase") == true)//Essa condição verifica se o player encostou com um objeto com rotulo Fire
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }

    }
    


}