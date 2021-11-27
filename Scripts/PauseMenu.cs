using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
	
	public static bool pauseLock = false;
	public static PauseMenu pauseMenu;
	public bool isPauseButtonPressed = false;
	
	private Ball ball;
	private Vector2 ballLastVelocity;
	
	void Awake (){
		if (pauseMenu != null){
			Destroy (gameObject);
		}
		else {
			pauseMenu = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}
	
	void Start (){
		GetComponent<Canvas>().enabled = false;
	}
	
	void Update (){
		if (!pauseLock){
			if (Input.GetKeyDown(KeyCode.Escape)){
				if (Application.loadedLevel != 0 && Application.loadedLevel != 1 && Application.loadedLevel != 5 && Application.loadedLevel != 6){
					GetComponent<AudioSource>().Play();
					if(!isPauseButtonPressed){
						ball = GameObject.FindObjectOfType<Ball>();
						PauseGame();
					}
					else{
						ResumeGame();
					}
				}
			}
		}			
	}
	
	void PauseGame(){
		ballLastVelocity = ball.rigidbody2D.velocity;
		ball.rigidbody2D.velocity = new Vector2 (0, 0);
		ball.rigidbody2D.isKinematic = true;
		MusicPlayer.musicPlayer.GetComponent<AudioSource>().Pause();
		Paddle.isPaused = true;
		GetComponent<Canvas>().enabled = true;
		isPauseButtonPressed = true;
		//Debug.Log ("Game Paused");
	}
	
	public void ResumeGame(){
		if (Application.loadedLevel != 1 && Application.loadedLevel != 5 && Application.loadedLevel != 6){
			ball.rigidbody2D.isKinematic = false;
			ball.rigidbody2D.velocity = ballLastVelocity;
		}
		MusicPlayer.musicPlayer.GetComponent<AudioSource>().Play();
		GetComponent<Canvas>().enabled = false;
		isPauseButtonPressed = false;
		Paddle.isPaused = false;
		//Debug.Log("Game Resumed");
	}
}
