using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour 
{

	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensitivityX = 15f;
	public float sensitivityY = 15f;
	
	public float minimumX = -360f;
	public float maximumX = 360f;
	
	public float minimumY = -60f;
	public float maximumY = 60f;
	
	float rotationX = 0f;
	float rotationY = 0f;
	
	Quaternion originalRotation;
	public bool paused = false;

	private InteractiveController lastHighlightedItem = null;

	public List<Items> inventory = new List<Items>();

	void Update ()
	{
		if (DisabledMouseInput()) 
			return;


		if (axes == RotationAxes.MouseXAndY)
		{
			// Read the mouse input axis
			rotationX += Input.GetAxis("Mouse X") * sensitivityX;
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			
			rotationX = ClampAngle (rotationX, minimumX, maximumX);
			rotationY = ClampAngle (rotationY, minimumY, maximumY);
			
			Quaternion xQuaternion = Quaternion.AngleAxis (rotationX, Vector3.up);
			Quaternion yQuaternion = Quaternion.AngleAxis (rotationY, -Vector3.right);
			
			transform.localRotation = originalRotation * xQuaternion * yQuaternion;
		}
		else if (axes == RotationAxes.MouseX)
		{
			rotationX += Input.GetAxis("Mouse X") * sensitivityX;
			rotationX = ClampAngle (rotationX, minimumX, maximumX);
			
			Quaternion xQuaternion = Quaternion.AngleAxis (rotationX, Vector3.up);
			transform.localRotation = originalRotation * xQuaternion;
		}
		else
		{
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY = ClampAngle (rotationY, minimumY, maximumY);
			
			Quaternion yQuaternion = Quaternion.AngleAxis (-rotationY, Vector3.right);
			transform.localRotation = originalRotation * yQuaternion;
		}

		CheckForInteractiveObject();
	}

	void CheckForInteractiveObject()
	{
		var cam = Camera.main.transform;
		var ray = new Ray(cam.position, cam.forward);
		
		RaycastHit hit;

		if(Physics.Raycast (ray, out hit, 1000))
		{
			var interactiveObject = hit.collider.gameObject.GetComponent<InteractiveController>();
			
			if (interactiveObject != null)
			{
				interactiveObject.Highlight();
				lastHighlightedItem = interactiveObject;
			}

			if ( lastHighlightedItem != interactiveObject)
			{
				lastHighlightedItem.DontHighlight();
			}
		}
		else
		{
			if (lastHighlightedItem != null)
			{
				lastHighlightedItem.DontHighlight();
			}
		}
	}
	
	void Start ()
	{
		// Make the rigid body not change rotation
		if (rigidbody)
			rigidbody.freezeRotation = true;
		originalRotation = transform.localRotation;
	}
	
	public static float ClampAngle (float angle, float min, float max)
	{
		if (angle < -360f)
			angle += 360f;
		if (angle > 360f)
			angle -= 360f;
		return Mathf.Clamp (angle, min, max);
	}

	bool DisabledMouseInput()
	{
		return paused;
	}

	public void Continue()
	{
		paused = false;
	}

	public void Pause()
	{
		paused = true;
	}

	public bool HasItem(Items item)
	{
		return inventory.Contains(item);
	}

	public void GivesItem(Items item)
	{
		if (!inventory.Contains(item))
		{
			inventory.Add(item);
		}
	}
}
