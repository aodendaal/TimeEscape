using UnityEngine;
using System.Collections;

public class LockCursor : MonoBehaviour {

	void OnMouseDown() {
		Screen.lockCursor = true;
	}
	private bool wasLocked = false;
	void Update() {
		if (Input.GetKeyDown("escape"))
			Screen.lockCursor = false;
		
		if (!Screen.lockCursor && wasLocked) {
			wasLocked = false;

		} else
		if (Screen.lockCursor && !wasLocked) {
			wasLocked = true;

		}
	}
}
