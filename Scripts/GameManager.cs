using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	private static GameManager gameManager = null;
	
	void Awake (){
		if (gameManager != null){
			Destroy (gameObject);
		}
		else {
			gameManager = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}
	
	void Update (){
		CursorVisibility();
	}
	
	void CursorVisibility(){
		if (!Paddle.isPaused){
			if (Application.loadedLevel == 1 || Application.loadedLevel == 5 || Application.loadedLevel == 6){
				Screen.showCursor = true;
			}
			else {
				Screen.showCursor = false;
			}
		}
		else {
			Screen.showCursor = true;
		}
	}
}
