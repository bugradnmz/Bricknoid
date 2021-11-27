using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	public static MusicPlayer musicPlayer = null;
		
	void Awake (){
		//Debug.Log ("Music Player Awake: " + GetInstanceID());
		if (musicPlayer != null){
			Destroy (gameObject);
			//print ("Duplicate Music Player self-destructing!");
		}
		else {
			musicPlayer = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}

	void Start (){
		//Debug.Log ("Music Player Start: " + GetInstanceID());
	}
}
