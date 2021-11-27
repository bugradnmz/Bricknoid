using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BrickText : MonoBehaviour {

	private Text brickText;
	
	void Start () {
		brickText = this.GetComponent<Text>();
	}
	
	void Update () {
		brickText.text = "Bricks Left: " + Brick.breakableCount.ToString();
	}
}
