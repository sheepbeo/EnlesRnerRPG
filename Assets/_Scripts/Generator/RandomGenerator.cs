using UnityEngine;
using System.Collections;

public class RandomGenerator : ObjectGenerator {

	public Vector3 randomRange;

	protected override void recycle() {
		_nextPos += gap;
		Vector3 randomGap = new Vector3(
			Random.Range(-randomRange.x, randomRange.x),
			Random.Range(-randomRange.y, randomRange.y),
			Random.Range(-randomRange.z, randomRange.z)
		);

		_nextPos += randomGap;
		
		Transform obj = pool.GetLast();
		obj.position = _nextPos;
		pool.Recycle(obj);

		_nextPos -= randomGap;
	}
}
