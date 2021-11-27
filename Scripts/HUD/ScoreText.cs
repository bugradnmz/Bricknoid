using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {

	private Text scoreText;

	void Start () {
		scoreText = this.GetComponent<Text>();
	}

	void Update () {
		scoreText.text = "Score: " + Ball.score.ToString();
	}
}
