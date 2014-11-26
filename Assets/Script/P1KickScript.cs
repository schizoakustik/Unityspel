using UnityEngine;
using System.Collections;

public class P1KickScript : MonoBehaviour {
	// Use this for initialization

	public float kickForce = 200f;
	public float moveX;
	public float moveY;

	float kickX;
	float kickY;

	void Start () {
	}

	// Update is called once per frame
	void Update () {
		moveX = transform.parent.rigidbody2D.velocity.x;
		moveY = transform.parent.rigidbody2D.velocity.y;
	}

	void OnCollisionEnter2D(Collision2D kick) {
		if (kick.gameObject.tag == "Ball") {
			if (moveX < .3f)
				moveX = .3f;

			if (moveY < 1.2f)
				moveY = 1.2f;

			kickX = (kickForce * moveX) / 2;
			kickY = (kickForce * moveY);

			if (kickY > 200)
				kickY = 200;
			
			Debug.Log("kickX: " + kickX + ", kickY: " + kickY);
			
			kick.gameObject.rigidbody2D.AddForce(new Vector2(kickX, kickY));
		}
	}
	
}