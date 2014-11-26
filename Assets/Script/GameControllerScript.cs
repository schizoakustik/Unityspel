using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameControllerScript : MonoBehaviour {
	// PLAYERS, BALL AND ENEMIES

	public GameObject[] Players;
	public GameObject Ball;
	public GameObject enemy;

	public Text[] score;

	private int Player1Score = 0;
	private int Player2Score = 0;

	// BACKGROUND, PIPES AND STUFF

	public Sprite[] Backgrounds;
	public GameObject backgroundImage;
	public GameObject[] upperPipes;
	public GameObject[] lowerPipes;

	// WINNING

	public GameObject[] playerwins;
	GameObject winPanel;

	// GAME MODES

	public bool endlessMode = false;

	//POWER UPS
	public float powerUpSpawningTime = 15f;
	private float lastTime = 0f;

	// Use this for initialization
	void Start () {
		Player1Score = 0;
		Player2Score = 0;
		backgroundImage.GetComponent<SpriteRenderer>().sprite = Backgrounds[0];
	}

	void FixedUpdate() {
	}

	// Update is called once per frame
	void Update() {
		if((Time.time - lastTime) > powerUpSpawningTime) {
			lastTime = Time.time;
			spawnEnemy();
		}
	}

	public void changeBackground() {
		Sprite backgroundSprite = backgroundImage.GetComponent<SpriteRenderer>().sprite;
		if (backgroundSprite == Backgrounds[0]) {
			backgroundSprite = Backgrounds[1];
			Debug.Log(backgroundSprite);
		}
	}
	
	public void UpdateScore(string whichHit) {
		if (whichHit == "leftGoal")
			Player2Score++;
		if (whichHit == "rightGoal")
			Player1Score++;
		if (whichHit == "enemyP1")
			Player1Score--;
		if (whichHit == "enemyP2")
			Player2Score--;

		score[1].text = Player2Score.ToString();
		score[0].text = Player1Score.ToString();

		if (whichHit == "leftGoal" || whichHit == "rightGoal")
			ResetPositions();

		if (Player1Score == 5 && !endlessMode)
			endGame(0);

		if (Player2Score == 5 && !endlessMode)
			endGame(1);
	}

	void ResetPositions() {
		// Reset ball position

		float randomPipe = (upperPipes[Random.Range(0, 3)].transform.position.x);
		Ball.transform.position = new Vector3(randomPipe, 0.8f, 0);
		Ball.rigidbody2D.velocity = new Vector2(0, 0);

		// Reset player positions
		Players[0].transform.position = new Vector2(-0.62f, -0.8f);
		Players[0].transform.rotation = new Quaternion(0, 0, 0, 0);
		Players[1].transform.position = new Vector2(0.82f, -0.8f);
		Players[1].transform.rotation = new Quaternion(0, 0, 0, 0);
	}

	void spawnEnemy() {
		//int randomPowerUp = Random.Range(0, powerUps.Length);
		float randomPipe = (upperPipes[Random.Range(0, 3)].transform.position.x);
		Vector2 randomPos = new Vector2(randomPipe, 0.8f);
		Instantiate(enemy, randomPos, transform.rotation);
	}

	public void setEndlessMode() {
		endlessMode = !endlessMode;
		}

	void endGame(int winner) {
		Time.timeScale = 0.03f;
		winPanel = Instantiate (playerwins[winner]) as GameObject;
		winPanel.name = playerwins[winner].name;
		winPanel.transform.SetParent (GameObject.Find("Canvas").transform, false);
	}

	public void Restart() {
		Application.LoadLevel(0);
		Time.timeScale = 1;
		}
}
