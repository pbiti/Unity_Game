using UnityEngine;
using System.Collections;

public class trackingclicks : MonoBehaviour {

	public static int totalclicks=0;
	public KeyCode mouseclick;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (mouseclick))
		{
			totalclicks += 1;


		}

		if (totalclicks >= 5) 
		{
			Debug.Log ("FAIL!!!");
			totalclicks = 0;
		}
	
	}
}
