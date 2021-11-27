using UnityEngine;
using System.Collections;

public class PaddleStartMenu : MonoBehaviour {
	
	public float minXPosOfPaddle, maxXPosOfPaddle;
	
	private BallStartMenu ball;
	private Vector3 paddlePos;
	private Vector3 ballPos;
	
	void Start() {
		ball = GameObject.FindObjectOfType<BallStartMenu>();
		RandomStart();
	}
	
	void Update () {
		AutoPlay();
	}
	
	public void AutoPlay(){
		float ballPosOnX = ball.transform.position.x;
		paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		
		paddlePos.x = Mathf.Clamp(ballPosOnX, minXPosOfPaddle, maxXPosOfPaddle);
		this.transform.position = paddlePos;
	}
	
	public void RandomStart(){
		ballPos.y = ball.transform.position.y;
		paddlePos.y = this.transform.position.y;
		float ballToPaddleVectorOnY =  ballPos.y - paddlePos.y;
		
		paddlePos = new Vector3 (Random.Range(minXPosOfPaddle, maxXPosOfPaddle), 0.5f, 0f);
		this.transform.position = paddlePos;
		ball.transform.position = paddlePos + new Vector3 (0f, ballToPaddleVectorOnY, 0f);
		LaunchBall();
	}
	
	void LaunchBall (){
		float LaunchVelocityOnX;
		LaunchVelocityOnX = this.transform.position.x - 8;
		ball.rigidbody2D.velocity = new Vector2 (LaunchVelocityOnX, 10f);
	}
}
