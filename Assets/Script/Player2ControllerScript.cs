using UnityEngine;
using System.Collections;

public class Player2ControllerScript : MonoBehaviour {
	Animator anim;
	//	public GameObject gameController;

	public float maxSpeed = 2f;
	public bool canJump = true;
	public bool doubleJump = false;
	public bool grounded = false;
	public float invulnerableTime = 3f;
	private float lastTime = 0f;
	public Transform groundCheck;
	GameObject gameController;
	GameObject[] upperPipes;
	GameObject[] lowerPipes;
	float randomPipe;
	public float jumpForce = 225f;
	float groundRadius = .2f;
	public LayerMask whatIsGround;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		gameController = GameObject.Find("GameControllerObject");
		upperPipes = gameController.GetComponent<GameControllerScript>().upperPipes;
		lowerPipes = gameController.GetComponent<GameControllerScript>().lowerPipes;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "upperPipe" && rigidbody2D.velocity.y > 0) {
			Debug.Log(gameObject.name + " entered upper pipe at position " + other.transform.position.x + " going upwards.");
			float randomLowerPipe = (lowerPipes[Random.Range(0, 2)].transform.position.x);
			Debug.Log(randomLowerPipe);
			transform.position = new Vector3(randomLowerPipe, -.2f, 0);
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if (Input.GetAxis("P2Vertical") < 0) {
			randomPipe = (upperPipes[Random.Range(0, 3)].transform.position.x);

			Debug.Log(randomPipe);
			transform.position = new Vector3(randomPipe, 0.8f, 0);
			rigidbody2D.velocity = new Vector2(0, 0);
			transform.rotation = new Quaternion(0, 0, 0, 0);
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "enemy" && (Time.time - lastTime) > invulnerableTime) {
			lastTime = Time.time;
			float hitDir = other.gameObject.rigidbody2D.velocity.x;
			rigidbody2D.AddForce(new Vector2((hitDir * 50), 80));
			gameController.GetComponent<GameControllerScript>().UpdateScore("enemyP2");
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//	grounded = GameObject.Find("GameControllerObject").GetComponent<GameControllerScript>().p2Grounded;

		float move = Input.GetAxis("P2Horizontal");
		rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);

		anim.SetFloat("hSpeed", rigidbody2D.velocity.x);

		if (grounded)
			doubleJump = false;
	}

	void Update () {
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

		if(grounded)
			anim.SetBool("grounded", true);
		else
			anim.SetBool("grounded", false);

		if((grounded || !doubleJump) && Input.GetButtonDown("P2Jump") && canJump) {
			//	if((grounded || !doubleJump) && (Input.GetAxis("P2Vertical") >= 0.01f) && canJump) {
			rigidbody2D.AddForce(new Vector2(0, jumpForce));

			if(!doubleJump && !grounded){
				doubleJump = true;
				anim.SetBool("doubleJump", true);
			}
			else
				anim.SetBool("doubleJump", false);
			
		}

		if (Input.GetButton("P2Kick"))
			anim.SetBool("kick", true);
		else
			anim.SetBool("kick", false);

		if (Input.GetAxis("P2Vertical") < 0)
			anim.SetBool("crouch", true);
		else
			anim.SetBool("crouch", false);	
	
	}

}
