using UnityEngine;
using System.Collections;

public class BallControllerScript : MonoBehaviour {
	private int Player1Score = 0;
	private int Player2Score = 0;
	public GameObject gameController;

	public GUIText Player1ScoreText;
	public GUIText Player2ScoreText;
	public GUIText DebugText;
	private bool Player2;
	private float minY = -10f;
	public float bouncyBallTimer;
	//	private float lastTime = 0f;
	public float bounce = .8f;
	public float powerUpSpeed = 50f;
	public Sprite[] powerUpSprites;

	void Awake() {
		//	powerUpSprites = Resources.LoadAll<Sprite>("gundux");
		gameController = GameObject.Find("GameControllerObject");
	}

	// Use this for initialization
	void Start () {
		Player1Score = 0;
		Player2Score = 0;
		collider2D.sharedMaterial.bounciness = bounce;
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "washingMachine1") {
			Player2 = true;
			Player2Score++;
			UpdateScore();
		}

		if (other.gameObject.tag == "washingMachine2") {
			Player2 = false;
			Player1Score++;
			UpdateScore(); }

		if (other.gameObject.tag == "Player") {
			//	lastHitBy = other.gameObject;
			//	DebugText.text = "Last hit by " + lastHitBy.name;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "powerUp") {
			Destroy(other.gameObject);
			//	DebugText.text = "Hit " + other.gameObject.name;

			if (other.gameObject.name == "bouncyBallPrefab(Clone)") {
				BouncyBall();
			}

			if (other.gameObject.name == "playerSpeedUpPrefab(Clone)") {
				PlayerSpeedUp();
			}
		}
	}

	// Update is called once per frame
	void Update () {
		//	DebugText.text = "x: " + transform.position.x.ToString() + " y: " + transform.position.y.ToString();
		if(transform.position.y < minY) {
			transform.position = new Vector3(0, 0, 0);
			rigidbody2D.velocity = new Vector2(0, 0);
		}

		if((Time.time - bouncyBallTimer) > 15f) {
			collider2D.sharedMaterial.bounciness = bounce;
			DebugText.text = "";
		}
	}

	void UpdateScore() {
		GameObject P1 = gameController.GetComponent<GameControllerScript>().Player1;
		GameObject P2 = gameController.GetComponent<GameControllerScript>().Player2;
		if (Player2 == true) {
			Player2ScoreText.text = Player2Score.ToString();
		}
		else
			Player1ScoreText.text = Player1Score.ToString();

		transform.position = new Vector3(0, 0, 0);
		rigidbody2D.velocity = new Vector2(0, 0);
		P1.transform.position = new Vector2(-0.8f, -0.8f);
		P2.transform.position = new Vector2(1f, -0.8f);
		P1.transform.rotation = new Quaternion(0, 0, 0, 0);
		P2.transform.rotation = new Quaternion(0, 0, 0, 0);
		
	}

	void BouncyBall() {
		DebugText.text = "It's BOUNCY BALL!";
		collider2D.sharedMaterial.bounciness = 1f;
		bouncyBallTimer = Time.time;
		//Invoke("EndBouncyBall", 15);
	}

	/* void EndBouncyBall() {
		collider2D.sharedMaterial.bounciness = bounce;
		DebugText.text = "No more BOUNCY BALL...";
	} */

	void PlayerSpeedUp() {
		
		Debug.Log(gameController.GetComponent<GameControllerScript>().p1MaxSpeed);
		
	//	Debug.Log("Player 1: " + GameObject.Find("Player1").GetComponent<PlayerControllerScript>().maxSpeed);
	//	Debug.Log("Player 2: " + GameObject.Find("Player2").GetComponent<PlayerControllerScript>().maxSpeed);
		
	//	Debug.Log("Before: " + lastHitBy.GetComponentInChildren<SpriteRenderer>().sprite);
	//	lastHitBy.GetComponentInChildren<SpriteRenderer>().sprite = powerUpSprites[0];
	//	Debug.Log("After: " + lastHitBy.GetComponentInChildren<SpriteRenderer>().sprite);
		
		//DebugText.text = lastHitBy.name + " speed: " + lastHitBy.GetComponent<PlayerControllerScript>().maxSpeed;
		
		
	
	}

}
