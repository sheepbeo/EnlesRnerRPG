using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float speed = 2f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {

		rigidbody.velocity = new Vector3(speed, rigidbody.velocity.y, rigidbody.velocity.z);
	}
}
