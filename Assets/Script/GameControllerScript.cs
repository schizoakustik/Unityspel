using UnityEngine;
using System.Collections;

public class GameControllerScript : MonoBehaviour {
	//PLAYERS
	public GameObject Player1;
	public GameObject Player2;
	public float p1MaxSpeed = 2f;
	public float p2MaxSpeed = 2f;
	public float jumpForce = 125f;
	public bool p1CanJump = true;
	public bool p2CanJump = true;

	public bool p1Grounded = false;
	public bool p2Grounded = false;
	public Transform p1GroundCheck;
	public Transform p2GroundCheck;
	
	float groundRadius = 0.2f;
	
	public LayerMask whatIsGround;

	bool p1DoubleJump = false;
	bool p2DoubleJump = false;
	
	//POWER UPS
/* 	public float powerUpSpawningTime = 15f;
	private float lastTime = 0f; */

	public GUIText debugText;
//	public GameObject[] powerUpPrefabs;
	//static Camera mainCamera = Camera.main;

	// Use this for initialization
	void Start () {
	}

	void FixedUpdate() {
		//	debugText.text = Time.time.ToString();
		p1Grounded = Physics2D.OverlapCircle(p1GroundCheck.position, groundRadius, whatIsGround);
		p2Grounded = Physics2D.OverlapCircle(p2GroundCheck.position, groundRadius, whatIsGround);

		if(p1Grounded)
			p1DoubleJump = false;

		if(p2Grounded)
			p2DoubleJump = false;

		float p1Move = Input.GetAxis("P1Horizontal");
		float p2Move = Input.GetAxis("P2Horizontal");
		Player1.rigidbody2D.velocity = new Vector2(p1Move * p1MaxSpeed, Player1.rigidbody2D.velocity.y);
		Player2.rigidbody2D.velocity = new Vector2(p2Move * p2MaxSpeed, Player2.rigidbody2D.velocity.y);
	}

	// Update is called once per frame
	void Update() {
		
		if((p1Grounded || !p1DoubleJump) && Input.GetButtonDown("P1Jump") && p1CanJump) {
			Player1.rigidbody2D.AddForce(new Vector2(0, jumpForce));

			if(!p1DoubleJump && !p1Grounded)
				p1DoubleJump = true;
		}
		
		if((p2Grounded || !p2DoubleJump) && Input.GetButtonDown("P2Jump") && p2CanJump){
			Player2.rigidbody2D.AddForce(new Vector2(0, jumpForce));

			if(!p2DoubleJump && !p2Grounded)
				p2DoubleJump = true;
		}
		
	/* 	if((Time.time - lastTime) > powerUpSpawningTime) {
			lastTime = Time.time;
			float maxX = Random.Range(-15, 13);
			float maxY = Random.Range(4, 10);
			spawnPowerUp(maxX, maxY);
		} */
	}

	/* void spawnPowerUp(float maxX, float maxY) {
		int randomPowerUp = Random.Range(0, powerUpPrefabs.Length);
		Vector2 randomPos = new Vector2(maxX, maxY);
		Instantiate(powerUpPrefabs[randomPowerUp], randomPos, transform.rotation);
		} */

}
