using UnityEngine;
using System.Collections;

public class MopController : MonoBehaviour {

	public GameObject MopOnFloor;
	public GameObject MopInHand;
	// Use this for initialization
	void Start () {
		MopOnFloor.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (MopInHand.activeSelf)
		{
			MopOnFloor.SetActive(false);

		}
		else
		{
			MopOnFloor.SetActive(true);
		}
	}
}
