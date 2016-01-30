using UnityEngine;

public class DragController : MonoBehaviour 
{
	Rigidbody2D grabbedObject;
    
    void Update ()
    {
		if (Input.GetMouseButton(0)) 
		{
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			RaycastHit2D hit = Physics2D.Raycast (mousePos, Vector3.zero);
			if (hit.collider && hit.collider.gameObject.tag == "Draggable")
			{
				grabbedObject = hit.collider.attachedRigidbody;
			}
		}
        else
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