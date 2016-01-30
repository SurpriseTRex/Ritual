using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	Vector2 clickedPosition;

	public float playerSpeed;
	Rigidbody2D rigidBody;

	bool playerOverTable;

	SceneController sceneController;

	// UI
	GameObject tableSwitchPanel;

	void Start()
	{
		rigidBody = gameObject.GetComponent<Rigidbody2D>();
		playerSpeed = 20f;
		clickedPosition = Vector2.zero;
		playerOverTable = false;

		sceneController = GameObject.Find ("GLOBAL_SCRIPTS").GetComponent<SceneController> ();

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
		}

		if (playerOverTable && Input.GetKeyDown(KeyCode.E))
		{
			sceneController.loadNextLevel("table_scene");
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
}