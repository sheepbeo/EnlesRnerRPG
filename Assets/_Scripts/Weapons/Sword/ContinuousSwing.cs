using UnityEngine;
using System.Collections;

public class ContinuousSwing : MonoBehaviour {

	public float startZ = 45;
	public float endZ = -45;

	public float interval = 1f;

	private float timer = 0f;

	void Start () {
		
	}

	void Update () {
		timer = (timer + Time.deltaTime) % interval;

		float nextRotationZ = timer / interval * (endZ - startZ) + startZ;

		transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y, nextRotationZ);
	}
}
