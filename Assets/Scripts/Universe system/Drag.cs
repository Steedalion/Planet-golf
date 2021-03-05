using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Drag : MonoBehaviour
{
	public bool moveAllowed{get; private set;}
	public UnityEvent onClick;

	
	
	
	
	
	
	private Collider col;
	private Vector3 clickedPosition;
	private Rigidbody rb;

    void Start()
    {
	    rb = GetComponent<Rigidbody>();
	    col = GetComponent<Collider>();
    }

	protected void OnMouseDown()
	{
		clickedPosition = Input.mousePosition;
		moveAllowed =true;
		onClick?.Invoke();
	}
	protected void OnMouseDrag()
	{
			Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Debug.Log(touchPosition);
			Thrust(transform.position, touchPosition);
	}
	// OnMouseUp is called when the user has released the mouse button.
	protected void OnMouseUp()
	{
		moveAllowed = false;
	}

	private void Thrust(Vector3 planetPosition, Vector3 goalPosition)
	{
		Vector3 thrust = goalPosition - planetPosition;
		thrust.z = 0;
		// thrust *= Time.deltaTime;
		rb.AddForce(thrust);
	}
	
	
	


	

}
