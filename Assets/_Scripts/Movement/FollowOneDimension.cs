using UnityEngine;
using System.Collections;

public class FollowOneDimension : MonoBehaviour {

	public Vector3 offSet = Vector3.zero;

	public enum Dimension {
		x, y, z
	}

	public Dimension dimension = Dimension.x;
	public Transform target;

	void Update() {
		if (target != null) {
			Vector3 nextPos = transform.position;

			if (dimension == Dimension.x) {
				nextPos.x = target.position.x + offSet.x;
			} else if (dimension == Dimension.y) {
				nextPos.y = target.position.y + offSet.y;
			} else if (dimension == Dimension.z) {
				nextPos.z = target.position.z + offSet.z;
			}

			transform.position = nextPos;
		}
	}
}
