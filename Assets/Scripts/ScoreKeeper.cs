using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

	public static int score;
	private Text myText;
	
	void Start(){
		myText = GameObject.Find("Score").GetComponent<Text>();
		myText.text= getPoints().ToString();
	}
	
	public void ScorePoints(int points){
		score+=points;
		myText.text = score.ToString();
	}
	
	public static void ResetScore(){
		score =0;
	}
	
	public int getPoints(){
		return score;
	}
		
}
