using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class ObjectPool {

	public Transform Prefab;

	[Range(1,100)]
	public int GeneratingBatchCount = 1;

	private Queue<Transform> objectQueue = new Queue<Transform>();

#region Public functions
	public void CreateNew() {
		createObject();
	}

	public Transform GetLast() {
		if (objectQueue.Count == 0) {
			createObject();
		}

		Transform t = objectQueue.Dequeue();
		t.gameObject.SetActive(false);
		return t;
	}

	public void Recycle(Transform t) {
		if (t != null) {
			t.gameObject.SetActive(true);
			objectQueue.Enqueue(t);
		}
	}

	public Transform Peek() {
		return objectQueue.Peek();
	}

#endregion

	private void generate() {
		for (int i=0; i<GeneratingBatchCount; i++) {
			createObject();
		}
	}

	private void createObject() {

		Transform t = (Transform) GameObject.Instantiate(Prefab, Vector3.zero, Quaternion.identity);
		t.gameObject.SetActive(false);
		objectQueue.Enqueue(t);
	}
}
