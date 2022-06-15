using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonCtrl2 : MonoBehaviour
{
    // Start is called before the first frame update
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
         SceneManager.LoadScene("SampleScene");
    }
}
