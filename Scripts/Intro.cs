using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {

	void Start () {
		StartCoroutine (IntroCoroutine());
	}
	
	void Update(){
		if (Input.anyKeyDown){
			Application.LoadLevel("Start Menu");
		}
	}
	
	private IEnumerator IntroCoroutine(){
		yield return new WaitForSeconds(4);
		Application.LoadLevel("Start Menu");
	}
}
