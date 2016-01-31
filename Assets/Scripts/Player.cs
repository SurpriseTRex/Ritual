using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	Vector2 clickedPosition;

	public float playerSpeed;
	Rigidbody2D rigidBody;

	bool playerOverTable;
	GameObject bodies;

	SceneController sceneController;
	Animator anim;

	// UI
	GameObject tableSwitchPanel;

	void Awake()
	{		
		sceneController = GameObject.Find ("GLOBAL_SCRIPTS").GetComponent<SceneController> ();
		anim = GetComponent<Animator> ();

		bodies = GameObject.Find ("bodies");

		rigidBody = gameObject.GetComponent<Rigidbody2D>();
		rigidBody.position = sceneController.playerPosition;
		playerSpeed = 4f;
		clickedPosition = Vector2.zero;
		playerOverTable = false;

		// UI
		tableSwitchPanel = GameObject.Find ("Table_Switch_Panel");
		tableSwitchPanel.SetActive (false);
	}

	void Update () 
	{
		if (Input.GetMouseButtonDown (0) && gameObject.tag == "Player")
		{
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			clickedPosition = new Vector2(mousePos.x, mousePos.y);
			setAnimation(clickedPosition);
		}

		if (playerOverTable && Input.GetKeyDown(KeyCode.E))
		{
			sceneController.playerPosition = rigidBody.position;
			sceneController.loadNextLevel("table_scene");
		}

		if (rigidBody.position.y > bodies.transform.position.y)
		{
			Vector3 bodiesPos = bodies.transform.position;
			bodiesPos.z = -2;
			bodies.transform.position = bodiesPos;
		}
		else
		{
			Vector3 bodiesPos = bodies.transform.position;
			bodiesPos.z = 0;
			bodies.transform.position = bodiesPos;
		}
	}

	void FixedUpdate()
	{
		if (clickedPosition.magnitude > 0)
		{
			rigidBody.position = Vector2.MoveTowards (rigidBody.position, clickedPosition, playerSpeed * Time.fixedDeltaTime);
			if ((rigidBody.position - clickedPosition).magnitude < 0.1)
			{
				clickedPosition = Vector2.zero;
				setAnimation(clickedPosition);
			}
		}
		else
		{
			clickedPosition = Vector2.zero;
		}
	}

	public void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Table")
		{
			tableSwitchPanel.SetActive(true);
			playerOverTable = true;
		} 
	}

	public void OnTriggerExit2D(Collider2D col)
	{
		tableSwitchPanel.SetActive(false);
		playerOverTable = false;
	}

	void OnCollisionEnter2D(Collision2D col) 
	{
		if (col.gameObject.name == "bg_group")
		{
			clickedPosition = Vector2.zero;
			setAnimation(clickedPosition);
		}
	}

	void setAnimation(Vector2 clickedPosition)
	{
		// Set INT for Animations
		// 0 == Idle
		// 1 == Up
		// 2 == Down
		// 3 == Side
		if (clickedPosition == Vector2.zero)
		{
			anim.SetInteger("Direction", 0);
		}
		else
		{
			Vector2 posDiff = clickedPosition - rigidBody.position;
			if (Mathf.Abs(posDiff.x) > Mathf.Abs(posDiff.y))
			{
				anim.SetInteger("Direction", 3);
				if ((clickedPosition - rigidBody.position).x < 0)
				{
					Vector3 transformScale = transform.localScale;
					if (transformScale.x > 0)
					{						
						transformScale.x *= -1;
						transform.localScale = transformScale;
					}
				}
				else if ((clickedPosition - rigidBody.position).x > 0)
				{
					Vector3 transformScale = transform.localScale;
					if (transformScale.x < 0)
					{						
						transformScale.x *= -1;
						transform.localScale = transformScale;
					}
				}
			}
			else
			{
				if ((clickedPosition - rigidBody.position).y > 0)
				{
					anim.SetInteger("Direction", 1);
				}
				else if ((clickedPosition - rigidBody.position).y < 0)
				{
					anim.SetInteger("Direction", 2);
				}
			}
		}
	}
}