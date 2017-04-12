using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthKeeper : MonoBehaviour {
	
	public int health =0;
	private Text myText;
	public float rate =0.5f;
	private PlayerController ship;
	
	void Start(){
		ship =GameObject.Find("SpaceShip").GetComponent<PlayerController>();
		myText =GameObject.Find("Health").GetComponent<Text>();
		myText.text="Nothing";
		RetrieveHealthFromShip();
	}
	
	public void RetrieveHealthFromShip(){
		health =ship.GetCurrentHealth();
		myText.text = health.ToString();
	}
	
	public void SetHealth(int healthA){
		if(healthA>0){
			myText.text = healthA.ToString();
			}else{
				myText.text = "0";
			}
	}
	
}
