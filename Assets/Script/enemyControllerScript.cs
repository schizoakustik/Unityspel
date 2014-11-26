using UnityEngine;
using System.Collections;

public class enemyControllerScript : MonoBehaviour {
	Animator anim;
	public bool enemyMove = false;
	public LayerMask whatIsGround;
	public Vector2[] enemyMovement;
	Vector2 enemyDir;
	//Vector2 still = new Vector2(0, 0);

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		enemyDir = enemyMovement[(Random.Range(0, 2))];
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "rightGoal") {
			enemyDir = enemyMovement[1];
		}

		if (other.gameObject.tag == "leftGoal") {
			enemyDir = enemyMovement[0];
		}

		if (other.gameObject.tag == "ground") {
			enemyMove = true;
		}

		if (other.gameObject.tag == "Ball") {
			enemyDeath();
		}
	}

	// Update is called once per frame
	void Update () {
		if (enemyMove == true)
			rigidbody2D.velocity = enemyDir;

		if (transform.position.y < -10f)
			Destroy(gameObject);
	}

	public	void enemyDeath() {
		anim.SetBool("ballHit", true);
		enemyMove = false;
		rigidbody2D.AddForce(new Vector2(0, 300f));
		rigidbody2D.velocity = new Vector2(0, 0);
		collider2D.enabled = false;
	}
}
