using UnityEngine;
using System.Collections;

public class BrickStartMenu : MonoBehaviour {
	
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public GameObject brickDestroyEffect;
	public Color effectColor;
	
	private StartMenu startMenu;
	private int timesHit;
	private bool isBreakable;
	
	void Start () {
		isBreakable = (this.tag == "Breakable");
		if (isBreakable){
			breakableCount++;
		}
		
		timesHit = 0;
		startMenu = GameObject.FindObjectOfType<StartMenu>();
	}
	
	// Tuğla kırıldıktan sonra topun sekmesini garantilemek için OnCollisionEnter2D yerine OnCollisionExit2D yazdım.
	void OnCollisionExit2D (Collision2D collision){
		if (isBreakable) {
			HandleHits();
		}
	}
	
	void HandleHits () {
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits){
			breakableCount--;
			//print ("Breakable bricks: " + breakableCount);
			BrickDestroyEffect();
			startMenu.LoopAutoPlay();
			Destroy(gameObject);
		}
		else {
			LoadSprites();
		}
	}
	
	void BrickDestroyEffect (){
		brickDestroyEffect.particleSystem.startColor = effectColor;
		GameObject.Instantiate(brickDestroyEffect, gameObject.transform.position, Quaternion.identity);
		
	}
	
	void LoadSprites(){
		int spriteIndex = timesHit - 1;
		if (hitSprites[spriteIndex]){
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
		else{
			Debug.LogError("One or more of your bricks hasn't got sprite");
		}
	}
}