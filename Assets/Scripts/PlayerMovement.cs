using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

	public Transform CameraPosition;

	public Vector3 PositionPause;

	public CharacterController2D controller;

	public Animator animator;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
    
    int tempo = 30;
    int tempo_escudo;

	bool jump = false;
	bool crouch = false;
	
    public static bool escudo = false;

	public static bool preso = false;

	public static Vector3 LocalPreso;
	
    public Transform Morto;

	private bool first = true;
	
	
	// Update is called once per frame
	void Update () {
		
		if(Pause.pause == true)
		{

			if(first == true)
			{
				PositionPause = gameObject.transform.position;
				first = false;
			}

			gameObject.transform.position = PositionPause;

			animator.StartPlayback();
			return;
		}
		animator.StopPlayback();

		first = true;

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
		}

		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		} else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}
		
		if (Input.GetButtonDown("Escudo") && escudo == false)
		{

			escudo = true;
			tempo_escudo = tempo;

			if(PlayerMovement.preso == true)
			{

              	CharacterController2D.m_Rigidbody2D.gravityScale = 1;
				PlayerMovement.preso = false;

			}

		}

		if(escudo == true)
		{

			tempo_escudo--;

			if(tempo_escudo == 0)
			{
				escudo = false;
			}

		}
		
		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
      	animator.SetBool("Escudo", escudo);
		animator.SetBool("Preso", preso);
		
        if(ItensPicker.Itens == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
            
        }
		

	}

	void FixedUpdate ()
	{

		if(ItensPicker.live <= 0)
		{

			if(Pause.pause == true)
			{

				if(first == true)
				{
					PositionPause = gameObject.transform.position;
					first = false;
				}

				gameObject.transform.position = PositionPause;

				animator.StartPlayback();
				return;
			}
			animator.StopPlayback();

			first = true;

			Instantiate(Morto, CameraPosition.position - new Vector3(0, 0, CameraPosition.position.z), CameraPosition.rotation);
			Destroy(gameObject);

		}
			
		if(preso == false)
		{
			
			if(Pause.pause == true)
			{

				if(first == true)
				{
					PositionPause = gameObject.transform.position;
					first = false;
				}

				gameObject.transform.position = PositionPause;

				animator.StartPlayback();
				return;
			}
			animator.StopPlayback();

			first = true;

			
			controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
			jump = false;
		
		}else
		{

			gameObject.transform.position = LocalPreso;

		}


	}
}
