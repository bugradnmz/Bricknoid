using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {
	
	public static StartMenu startMenu = null;
	
	void Awake (){
		//Debug.Log ("Start Menu Awake: " + GetInstanceID());
		if (startMenu != null){
			Destroy (gameObject);
			//print ("Duplicate Start Menu self-destructing!");
		}
		else {
			startMenu = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}
	
	void Start (){
		//Debug.Log ("Start Menu Active: " + GetInstanceID());
	}
	
	//Arkaplanda oyun devamlı oynansın diye yazdığım method.
	public void LoopAutoPlay(){
		
		if(BrickStartMenu.breakableCount <= 0){
			print ("Looping Auto Play");
			Application.LoadLevel ("Start Menu");
			print ("Loop succesful.");
		}
	}
}
