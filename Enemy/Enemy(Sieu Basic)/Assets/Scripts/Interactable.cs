using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

	public float radius = 3f;
	public Transform interactionTransform;

	bool isFocus = false;
	Transform player;

	bool hasInteracted = false;

	public virtual void Interact()
	{
		// This method is meant to be overwritten
		//Debug.Log("Interacting with " + transform.name);
	}

	void Update()
	{
		// If we are currently being focused
		// and we haven't already interacted with the object
		if (isFocus && !hasInteracted)
		{
			// If we are close enough
			float distance = Vector3.Distance(player.position, interactionTransform.position);
			if (distance <= radius)
			{
				// Interact with the object
				Interact();
				hasInteracted = true;
			}
		}
	}

	public void OnFocused (Transform playerTransform)
    {
		isFocus = true;
		player = playerTransform;
		hasInteracted = false;
    }

	public void OnDefocused ()
    {
		isFocus = false;
		player = null;
		hasInteracted = false;
    }

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(interactionTransform.position, radius);
	}

}
