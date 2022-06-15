using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCtrl1 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject activate;
    public GameObject deactivate;
    public Button yourButton;
    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TaskOnClick(){
        deactivate.SetActive(false);
        activate.SetActive(true);
    }
}
