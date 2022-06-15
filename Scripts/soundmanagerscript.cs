using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundmanagerscript : MonoBehaviour
{
	public static AudioClip jumpSound;
	static AudioSource audiosrc;
    // Start is called before the first frame update
    void Start()
    {
        jumpSound = Resources.Load<AudioClip>("jump");

        audiosrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip){
    	switch(clip){
    		case "jump":
    			audiosrc.PlayOneShot (Resources.Load<AudioClip>("jump"));
    			break;
    	}
    }
}