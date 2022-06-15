using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformmovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 2.5f;

    private void OnCollisionEnter2D(Collision2D collision){
        collision.collider.transform.SetParent(transform);
    }
    private void OnCollisionExit2D(Collision2D collision){
        collision.collider.transform.SetParent(null);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(Mathf.PingPong(Time.time * speed, 5), transform.position.y);
    }
}
