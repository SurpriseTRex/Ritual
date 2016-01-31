using UnityEngine;

public class DragController : MonoBehaviour 
{
    ToolItem heldItem;
    TargetItem targetItem;

    void Update ()
    {
		if (Input.GetMouseButton(0)) 
		{
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			RaycastHit2D hit = Physics2D.Raycast (mousePos, Vector3.zero);
			if (hit.collider && hit.collider.gameObject.tag == "Draggable")
			{
                heldItem = hit.collider.gameObject.GetComponent<ToolItem>();
			}

            if (heldItem != null)
            {
				bool intersecting = false;
                GameObject[] interactables = GameObject.FindGameObjectsWithTag("Interactable");
                for (int i = 0; i < interactables.Length; i++)
                {
                    if (DoObjectsIntersect(heldItem.gameObject, interactables[i]))
                    {
						intersecting = true;
                        targetItem = interactables[i].GetComponent<TargetItem>();
                        if (targetItem != null && !targetItem.activated)
                        {
                            heldItem.InteractWith(targetItem);
                        }
                    }
                }

				if (intersecting == false)
				{
					targetItem = null;
				}
            }
        }
        else
		{
            if (heldItem != null && targetItem != null)
            {
                heldItem.AddPoints();
            }
            targetItem = null;
            heldItem = null;
		}
    }

	void FixedUpdate()
	{
		if (heldItem != null) 
		{
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			heldItem.gameObject.GetComponent<Rigidbody2D>().position = mousePos;
        }
	}

    public bool DoObjectsIntersect(GameObject a, GameObject b)
    {
        Bounds aBounds = a.GetComponent<Collider2D>().bounds;
        Bounds bBounds = b.GetComponent<Collider2D>().bounds;
        return aBounds.Intersects(bBounds);
    }
}