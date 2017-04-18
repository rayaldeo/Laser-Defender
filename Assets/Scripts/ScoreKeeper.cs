using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

	public static int score =0;
	private Text myText;
	public float rate =0.5f;
	
	void Start(){
		myText = GameObject.Find("Score").GetComponent<Text>();
		ResetScore();
	}
	
	public void ScorePoints(int points){
		score+=points;
		myText.text = score.ToString();
	}
	
	public static void ResetScore(){
		score =0;
	}
		
}
