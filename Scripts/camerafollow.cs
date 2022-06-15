using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    private Transform player;
    private Transform tilemap;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find ("Idle").transform;
        //tilemap = GameObject.Find ("Tilemap (1)").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(player.position.x, -3f, 35f), 
        Mathf.Clamp(player.position.y, -100f, 6f), transform.position.z);
    }
}
