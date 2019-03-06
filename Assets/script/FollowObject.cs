using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour {
      
    public Transform target;        //Create new C# script and this code is for, "Camera movement that follows the player"
    public Vector3Int offset;
    public float lerpSpeed = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()

    {
        Vector3 desirePos = target.position + offset;

        transform.position = Vector3.Lerp(transform.position, desirePos, lerpSpeed * Time.deltaTime);


	}
}
