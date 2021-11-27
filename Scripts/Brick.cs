using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public AudioClip destroySound;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public GameObject brickDestroyEffect;
	public Color effectColor;
	
	private LevelManager levelManager;
	private int timesHit;
	private bool isBreakable;
	
	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		if (isBreakable){
			breakableCount++;
		}
		//print ("Breakable bricks: " + breakableCount);
	
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Tuğla kırıldıktan sonra topun sekmesini garantilemek için OnCollisionEnter2D yerine OnCollisionExit2D yazdım.
	void OnCollisionExit2D (Collision2D collision){
		AudioSource.PlayClipAtPoint(destroySound, transform.position, 0.5f);
		if (isBreakable) {
			Ball.brickCombo++;
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
			levelManager.BrickDestroyed();
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