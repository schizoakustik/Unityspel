using UnityEngine;
using System.Collections;

public class BallControllerScript : MonoBehaviour {
	public GameObject gameController;

	//	public GUIText DebugText;
	public GUIStyle winStyle;
	private bool Player2;
	private float minY = -10f;
	public float bouncyBallTimer;
	//	private float lastTime = 0f;
	public float bounce = 1f;
	public float powerUpSpeed = 50f;
	public Sprite[] powerUpSprites;

	GameObject lastHitBy;

	GameObject[] upperPipes;
	GameObject[] lowerPipes;

	void Awake() {
		//	powerUpSprites = Resources.LoadAll<Sprite>("gundux");
		gameController = GameObject.Find("GameControllerObject");
	}

	// Use this for initialization
	void Start () {
		collider2D.sharedMaterial.bounciness = bounce;
		upperPipes = gameController.GetComponent<GameControllerScript>().upperPipes;
		lowerPipes = gameController.GetComponent<GameControllerScript>().lowerPipes;
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "leftGoal") {
			gameController.GetComponent<GameControllerScript>().UpdateScore("leftGoal");
		}

		if (other.gameObject.tag == "rightGoal") {
			gameController.GetComponent<GameControllerScript>().UpdateScore("rightGoal");
		}

		if (other.gameObject.tag == "upperPipe" && rigidbody2D.velocity.y > 0) {
			float randomLowerPipe = (lowerPipes[Random.Range(0, 2)].transform.position.x);
			transform.position = new Vector2(randomLowerPipe, -.2f);
		}

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

	void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag == "leftGoal")
			rigidbody2D.AddForce(new Vector2(20, 0));
			
		if(other.gameObject.tag == "rightGoal")
			rigidbody2D.AddForce(new Vector2(-20, 0));
		}

	// Update is called once per frame
	void Update () {
		//	DebugText.text = "x: " + transform.position.x.ToString() + " y: " + transform.position.y.ToString();
		if(transform.position.y < minY) {
			float randomUpperPipe = (upperPipes[Random.Range(0, 2)].transform.position.x);
			transform.position = new Vector2(randomUpperPipe, 0.6f);
			rigidbody2D.velocity = new Vector2(0, 0);
		}

		if((Time.time - bouncyBallTimer) > 15f) {
			collider2D.sharedMaterial.bounciness = bounce;
		
		}
	}

	void BouncyBall() {
		
		collider2D.sharedMaterial.bounciness = 1f;
		bouncyBallTimer = Time.time;
		//Invoke("EndBouncyBall", 15);
	}

	/* void EndBouncyBall() {
		collider2D.sharedMaterial.bounciness = bounce;
		DebugText.text = "No more BOUNCY BALL...";
	} */

	void PlayerSpeedUp() {
		
	//	Debug.Log(gameController.GetComponent<GameControllerScript>().p1MaxSpeed);
		
	//	Debug.Log("Player 1: " + GameObject.Find("Player1").GetComponent<PlayerControllerScript>().maxSpeed);
	//	Debug.Log("Player 2: " + GameObject.Find("Player2").GetComponent<PlayerControllerScript>().maxSpeed);
		
	//	Debug.Log("Before: " + lastHitBy.GetComponentInChildren<SpriteRenderer>().sprite);
	//	lastHitBy.GetComponentInChildren<SpriteRenderer>().sprite = powerUpSprites[0];
	//	Debug.Log("After: " + lastHitBy.GetComponentInChildren<SpriteRenderer>().sprite);
		
		//DebugText.text = lastHitBy.name + " speed: " + lastHitBy.GetComponent<PlayerControllerScript>().maxSpeed;
		
		
	
	}

}
