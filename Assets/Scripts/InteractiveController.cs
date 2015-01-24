using UnityEngine;
using System.Collections;

public class InteractiveController : MonoBehaviour 
{
	private bool highlighting;
	public Sprite spriteToRender;
	// Use this for initialization
	void Start () {
		var icon = this.gameObject.GetComponentInChildren<SpriteRenderer>();
		icon.sprite = spriteToRender;

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
