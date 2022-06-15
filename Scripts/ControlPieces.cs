using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlPieces : MonoBehaviour
{
    // Start is called before the first frame update
    //Text text;
    private SpriteRenderer rend, rendback;
    private GameObject[] gos;
	private Color c, b;

    public GameObject delpap, background;
    public GameObject timer, timertxt;

    void Start()
    {
        //text = GetComponent<Text>();
        rend = gameObject.GetComponent<SpriteRenderer>();
        c = rend.material.color;
		c.a = 0f;
		rend.material.color = c;

        rendback = background.GetComponent<SpriteRenderer>();
	    b = rendback.material.color;
		b.a = 1f;
		rendback.material.color = b;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void startroutine(){
        StartCoroutine ("FadeIn");

        b = rendback.material.color;
        b.a = 0.60f;         
        rendback.material.color = b;
        
        Destroy(delpap);

        //Destroy(timer);
        //Destroy(timertxt);
    }

    IEnumerator FadeIn(){
		c = rend.material.color;
		for (float ca = 0.05f; ca <= 1f; ca += 0.05f){
			c.a = ca;
			rend.material.color = c;
			yield return new WaitForSeconds (0.05f);
        }
        SceneManager.LoadScene("LevelCompleted");
    }

}
