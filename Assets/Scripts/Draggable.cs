using UnityEngine;
using System.Collections.Generic;

public class Draggable : MonoBehaviour 
{
	Rigidbody2D grabbedObject;
    
    void Update ()
    {
		if (Input.GetMouseButtonDown (0)) 
		{
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector3 dir = Vector3.zero;

			RaycastHit2D hit = Physics2D.Raycast (mousePos, dir);
			if (hit != null && hit.collider.gameObject.tag == "Draggable")
			{
				grabbedObject = hit.collider.attachedRigidbody;
			}
		}

		if (Input.GetMouseButtonUp (0))
		{
			grabbedObject = null;
		}
    }

	void FixedUpdate()
	{
		if (grabbedObject != null) 
		{
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			grabbedObject.position = mousePos;
		}
	}
}