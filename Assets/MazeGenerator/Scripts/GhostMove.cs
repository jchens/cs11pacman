using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
  
    void Update()
    {
        // Set the x position to loop between 0 and 3
        transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time, 2), transform.position.z);
    }

}
