using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A simple hover effect to give the illusion of the chessboard floating in space.
/// </summary>
public class Hover : MonoBehaviour {

	float y0;
	public float amplitude;
	public float speed;
	private float offset;

	void Start () {

		offset = Random.Range(0.0f,1.0f);
		y0 = transform.position.y;

	}

	void Update () {

		Vector3 pos = transform.position;
		pos = new Vector3(pos.x , y0 + amplitude*Mathf.Sin(speed*(Time.time + offset)), pos.z);
		transform.position = pos;
	}

}
