using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehaviour : MonoBehaviour {
	// Use this for initialization
	Vector3 rotate;
	public float rotationSpeed = 30;
	void Start () {
		rotate = new Vector3(0,1,0);
	}

	// Update is called once per frame
	void Update () {
		transform.Rotate(rotate * Time.deltaTime * rotationSpeed);
	}
	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag == "Wall")
		{
			transform.parent = null;
			gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
		}
	}
	void OnCollisionExit(Collision col)
	{
			gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
	}
}
