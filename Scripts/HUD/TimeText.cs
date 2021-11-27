using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeText : MonoBehaviour {

	private Text timeText;
	private float timer;
	
	void Start () {
		timeText = this.GetComponent<Text>();
	}

	void Update () {
		if(Ball.hasGameStarted){
			timer += Time.deltaTime;
			timeText.text = "Time: " + Mathf.Round(timer).ToString();
		}
	}
}
