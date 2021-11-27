using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public static bool isPaused = false;
	public bool autoPlay;
	public float minXPosOfPaddle, maxXPosOfPaddle;
	
	private Ball ball;
	private Vector3 paddlePos;
	private Vector3 ballPos;
	
	void Start() {
		ball = GameObject.FindObjectOfType<Ball>();
		LevelManager.currentLevel = Application.loadedLevel;
		if (autoPlay){
			RandomStart();
		}
	}
	
	void Update () {
		if (!autoPlay){
			if (!isPaused){
				MoveWithMouse();
			}
		}
		else {
			AutoPlay();
		}
	}
	
	void MoveWithMouse (){
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		paddlePos = new Vector3 (8f, 0.5f, 0f);
		paddlePos.x = Mathf.Clamp(mousePosInBlocks, minXPosOfPaddle, maxXPosOfPaddle);
		this.transform.position = paddlePos;
	}
	
	void AutoPlay(){
		float ballPosOnX = ball.transform.position.x;
		paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		
		paddlePos.x = Mathf.Clamp(ballPosOnX, minXPosOfPaddle, maxXPosOfPaddle);
		this.transform.position = paddlePos;
	}
	
	void RandomStart(){
		ballPos.y = ball.transform.position.y;
		paddlePos.y = this.transform.position.y;
		float ballToPaddleVectorOnY =  ballPos.y - paddlePos.y;
		
		paddlePos = new Vector3 (Random.Range(minXPosOfPaddle, maxXPosOfPaddle), 0.5f, 0f);
		this.transform.position = paddlePos;
		ball.transform.position = paddlePos + new Vector3 (0f, ballToPaddleVectorOnY, 0f);
		
		Ball.hasGameStarted = true;
		LaunchBall();
	}
	
	void LaunchBall (){
		float LaunchVelocityOnX;
		LaunchVelocityOnX = this.transform.position.x - 8;
		ball.rigidbody2D.velocity = new Vector2 (LaunchVelocityOnX, 10f);
	}
}
