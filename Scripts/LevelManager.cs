using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

	public static LevelManager levelManager;
	public static int currentLevel;
	public AudioClip gameBGMusic;
	public AudioClip menuBGMusic;
	
	private MusicPlayer musicPlayer;
	private Ball ball;
	private ComboText comboText;
	
	void Awake (){
		if (levelManager != null){
			Destroy (gameObject);
		}
		else {
			levelManager = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}
	
	void Start(){
		musicPlayer = GameObject.FindObjectOfType<MusicPlayer>();
	}
	
	void Update(){
		if(Input.GetKeyDown(KeyCode.Space)){
			LoadNextLevel();
		}
	}
	
	public void LoadLevel(string name){
		//Debug.Log ("New Level load: " + name);
		Brick.breakableCount = 0;
		BrickStartMenu.breakableCount = 0;
		Ball.hasGameStarted = false;
		
		if (Application.loadedLevel == 1){
			StartMenu.startMenu.GetComponent<Canvas>().enabled = false;
			MusicPlayer.musicPlayer.GetComponent<AudioSource>().clip = gameBGMusic;
			MusicPlayer.musicPlayer.GetComponent<AudioSource>().volume = 0.25f;
			MusicPlayer.musicPlayer.GetComponent<AudioSource>().Play();
		}
		else{
			StartMenu.startMenu.GetComponent<Canvas>().enabled = true;
			MusicPlayer.musicPlayer.GetComponent<AudioSource>().clip = menuBGMusic;
			MusicPlayer.musicPlayer.GetComponent<AudioSource>().volume = 0.50f;
			MusicPlayer.musicPlayer.GetComponent<AudioSource>().Play();
			PauseMenu.pauseMenu.ResumeGame();
		}
		Application.LoadLevel (name);
	}
	
	public void LoadLoseScreen(){
		Brick.breakableCount = 0;
		Ball.hasGameStarted = false;
		Application.LoadLevel ("Lose Screen");
	}

	public void QuitRequest(){
		//Debug.Log ("Quit requested");
		Application.Quit ();
	}

	public void LoadNextLevel(){
		Brick.breakableCount = 0;
		Ball.hasGameStarted = false;
		StartCoroutine(LoadWithSound());
		
		//TODO Change after all levels done.
		if (currentLevel == 4){
			musicPlayer.GetComponent<AudioSource>().Stop();
		}
	}
	
	public void RestartLevel(){
		Brick.breakableCount = 0;
		Ball.hasGameStarted = false;
		PauseMenu.pauseMenu.ResumeGame();
		Application.LoadLevel (currentLevel);
	}
	
	public void BrickDestroyed(){
		if(Brick.breakableCount <= 0){
			FixScore();
			//Debug.Log (Ball.score);
			LoadNextLevel();
		}
	}
	
	IEnumerator LoadWithSound(){
		ball = GameObject.FindObjectOfType<Ball>();
		PauseMenu.pauseLock = true;
		GetComponent<AudioSource>().Play();
		Paddle.isPaused = true;
		ball.rigidbody2D.velocity = new Vector2 (0, 0);
		ball.rigidbody2D.isKinematic = true;
		yield return new WaitForSeconds(1);
		Application.LoadLevel (Application.loadedLevel + 1);
		Ball.hasGameStarted = false;
		Paddle.isPaused = false;
		ball.rigidbody2D.isKinematic = false;
		PauseMenu.pauseLock = false;
	}
	
	void FixScore(){
		float comboScore = Mathf.Pow(Ball.brickCombo, 2) * Ball.brickPoint;
		Ball.score = Ball.score + comboScore;
		comboText = GameObject.FindObjectOfType<ComboText>();
		comboText.GetComponent<Text>().text = "+" + comboScore.ToString() + 
											  " (" + Ball.brickPoint.ToString() + 
											  " x " + Ball.brickCombo.ToString() + 
											  " x " + Ball.brickCombo.ToString() + ")";
	}
}