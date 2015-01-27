using UnityEngine;
using System.Collections;

public class GumController : MonoBehaviour {

	public GameObject theJanitor;
	public GameObject theCleanerJanitor;
	private MeshRenderer renderer;
	// Use this for initialization
	void Start () {
		renderer = this.gameObject.GetComponent<MeshRenderer>();
		renderer.enabled = false;
		//this.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void ShowGum()
	{
		renderer.enabled = true;

		ShouldCleanFloor(true);

	}

	public void HideGum()
	{
		renderer.enabled = false;
		ShouldCleanFloor(false);
	}

	public void ShouldCleanFloor(bool shouldCleanFloor)
	{
		var animator = theJanitor.GetComponentInChildren<Animator>();
		if (animator != null)
		{
			animator.SetBool("CleanFloor", shouldCleanFloor);
		}
	}
}
