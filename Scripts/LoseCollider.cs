using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {
	
	private LevelManager levelManager;
	private MusicPlayer musicPlayer;
	private PauseMenu pauseMenu;
	
	void Start(){
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		musicPlayer = GameObject.FindObjectOfType<MusicPlayer>();
		pauseMenu = GameObject.FindObjectOfType<PauseMenu>();
	}

	void OnTriggerEnter2D (Collider2D trigger){
		musicPlayer.GetComponent<AudioSource>().Stop();
		StartCoroutine(GameOver());
	}
	
	IEnumerator GameOver(){
		PauseMenu.pauseLock = true;
		GetComponent<AudioSource>().Play();
		Paddle.isPaused = true;
		yield return new WaitForSeconds(2);
		pauseMenu.GetComponent<Canvas>().enabled = false;
		pauseMenu.isPauseButtonPressed = false;
		Paddle.isPaused = false;
		levelManager.LoadLoseScreen();
		PauseMenu.pauseLock = false;
	}
}
