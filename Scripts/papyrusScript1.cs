using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class papyrusScript1 : MonoBehaviour
{
	public static bool GameIsPaused = false;
	public GameObject PausePap1;
    public GameObject PausePap2;
    public GameObject PausePap3;
    public GameObject PausePap4;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
        	if(GameIsPaused){
        		ResumePap();
        	}
        }
    }

    public void PausePap(int numOfPap){
        if(numOfPap == 0){
            PausePap1.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }
        else if(numOfPap == 1){
            PausePap2.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }
        else if(numOfPap == 2){
            PausePap3.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }
        else if(numOfPap == 3){
            PausePap4.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }
    }

    void ResumePap(){
    	PausePap1.SetActive(false);
        PausePap2.SetActive(false);
        PausePap3.SetActive(false);
        PausePap4.SetActive(false);
    	Time.timeScale = 1f;
    	GameIsPaused = false;
    }
}
