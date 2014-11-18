using UnityEngine;
using System.Collections;

public class ObjectGenerator : MonoBehaviour {

	public ObjectPool pool;
	public int TotalObjectCount = 10;

	public Vector3 StartPos = Vector3.zero;
	protected Vector3 _nextPos = Vector3.zero;

	public Vector3 gap = new Vector3(1f,0f,0f);


	protected float _distantTraveled { get { return transform.position.x + StartPos.x; }}

	#region unity functions implementations
	void Start() {
		initialize();
	}

	protected virtual void initialize() {
		_nextPos = StartPos;
		for (int i=0; i<TotalObjectCount; i++) {
			pool.CreateNew();
		}
		for (int i=0; i<TotalObjectCount; i++) {
			recycle();
		}
	}

	void Update() {
		update();
	}

	protected virtual void update() {
		if (recycleConditionSatisfied()) {
			recycle();
		}
	}

	#endregion

	protected virtual bool recycleConditionSatisfied() {
		return _distantTraveled > (pool.Peek().position.x - StartPos.x);
	}

	protected virtual void recycle() {
		_nextPos += gap;

		Transform obj = pool.GetLast();
		obj.position = _nextPos;
		pool.Recycle(obj);
	}
}
