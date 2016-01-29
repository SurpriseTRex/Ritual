using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	Vector2 dir;
	Vector2 clickedPosition;

	public float playerSpeed;
	Rigidbody2D rigidBody;

	void Start()
	{
		rigidBody = gameObject.GetComponent<Rigidbody2D>();
		playerSpeed = 20f;
		clickedPosition = Vector2.zero;
	}

	void Update () 
	{
		if (Input.GetMouseButtonDown (0) && gameObject.tag == "Player")
		{
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			clickedPosition = new Vector2(mousePos.x, mousePos.y);
			dir = clickedPosition - rigidBody.position;
		}
	}

	void FixedUpdate()
	{
		if (clickedPosition.magnitude > 0)
		{
			rigidBody.position = Vector2.MoveTowards (rigidBody.position, clickedPosition, playerSpeed * Time.fixedDeltaTime);
		}
		else
		{
			clickedPosition = Vector2.zero;
		}
	}
}
