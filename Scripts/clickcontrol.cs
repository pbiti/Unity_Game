using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class clickcontrol : MonoBehaviour {

	public GameObject reveal;
	public static string nameofobj;
	public GameObject objnametext;
	public Transform objnametextPos;
	public Transform sucessclick;

	private ControlPieces scriptclick;

	private TimerControl timerctrl; 
	private GameObject[] gos;

	private IEnumerator fading;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()

	{
		nameofobj = gameObject.name;
		//Debug.Log (nameofobj);
		Destroy (gameObject);
		Destroy (objnametext);
		trackingclicks.totalclicks = 0;
		gos = GameObject.FindGameObjectsWithTag("piece");
		if(gos.Length -1 == 0 ){			
			scriptclick = FindObjectOfType<ControlPieces>();
			scriptclick.startroutine();
			timerctrl = FindObjectOfType<TimerControl>();
			timerctrl.EndGame();
			GameObject[] remove = GameObject.FindGameObjectsWithTag("removable");
			for(int i=0; i< remove.Length; i++)
			{
				Destroy(remove[i]);
			}
		}
		//Instantiate (sucessclick, objnametextPos.position, sucessclick.rotation);
	}
}
