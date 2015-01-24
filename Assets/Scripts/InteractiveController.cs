using UnityEngine;
using System.Collections;

public class InteractiveController : MonoBehaviour 
{
	private bool highlighting;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Highlight()
	{
		var highlighting = true;
		UpdateHighlight(highlighting);

	}

	public void DontHighlight()
	{
		var highlighting = false;
		UpdateHighlight(highlighting);
	}

	private void UpdateHighlight(bool highlighting)
	{
		var anim = this.gameObject.GetComponentsInChildren<Animator>()[0];
		anim.SetBool("Interact", highlighting);
	}
}
