using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelText : MonoBehaviour {

	private Text levelText;
	
	void Start () {
		levelText = this.GetComponent<Text>();
		levelText.text = "Level: " + (Application.loadedLevel - 1).ToString();
	}
}
