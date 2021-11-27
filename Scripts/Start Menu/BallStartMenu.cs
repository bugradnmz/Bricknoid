using UnityEngine;
using System.Collections;

public class BallStartMenu : MonoBehaviour {
	
	private PaddleStartMenu paddle;
	private float actualVelocity;
	private Vector3 paddleToBallVector;
	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<PaddleStartMenu>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
		this.transform.position = paddle.transform.position + paddleToBallVector;
	}
	
	void Update () {
		BallSpeedGuard();
	}
	
	void OnCollisionEnter2D (Collision2D collision){
		Tweak();
	}
	
	void Tweak(){
		Vector2 tweak = new Vector2 (Random.Range (-0.2f, 0.2f), Random.Range (-0.2f, 0.2f));
		rigidbody2D.velocity += tweak;
	}
	
	void BallSpeedGuard (){
		//Topun hızını bul.
		actualVelocity = Mathf.Sqrt(Mathf.Pow(rigidbody2D.velocity.x, 2) + Mathf.Pow(rigidbody2D.velocity.y, 2));
		//Top hızlı ise yavaşlat.
		if (actualVelocity > 10){
			Vector2 decreaseVelocity = rigidbody2D.velocity;
			
			//Top negatif yönde gidiyorsa pozitif yönde, pozitif yönde gidiyorsa negatif yönde hız ekle ki yavaşlasın.
			decreaseVelocity.x += (-0.01f * Mathf.Sign(decreaseVelocity.x));
			decreaseVelocity.y += (-0.01f * Mathf.Sign(decreaseVelocity.y));
			rigidbody2D.velocity = decreaseVelocity;
		}
		//Top yavaş ise hızlandır.
		else if (actualVelocity < 9.9){			
			Vector2 decreaseVelocity = rigidbody2D.velocity;
			
			//Top negatif yönde gidiyorsa negatif yönde, pozitif yönde gidiyorsa pozitif yönde hız ekle ki hızlansın.
			decreaseVelocity.x += (0.01f * Mathf.Sign(decreaseVelocity.x));
			decreaseVelocity.y += (0.01f * Mathf.Sign(decreaseVelocity.y));
			rigidbody2D.velocity = decreaseVelocity;
		}
	}
}
