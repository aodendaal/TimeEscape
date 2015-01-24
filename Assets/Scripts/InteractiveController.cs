using UnityEngine;
using System.Collections;

public class InteractiveController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Highlight()
	{
		var pos = this.transform.position;
		pos.y = pos.y+1;
		this.transform.position = pos;
	}
}
