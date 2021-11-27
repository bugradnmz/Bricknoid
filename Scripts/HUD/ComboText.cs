using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ComboText : MonoBehaviour {

	private Text comboText;
	
	void Start () {
		comboText = this.GetComponent<Text>();
	}
	
	void Update () {
		comboText.text = "+" + Ball.comboScore.ToString() + 
						 " (" + Ball.brickPoint.ToString() + 
						 " x " + Ball.brickCombo.ToString() + 
						 " x " + Ball.brickCombo.ToString() + ")";
	}
}
