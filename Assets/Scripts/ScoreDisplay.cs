using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreDisplay : MonoBehaviour {

	private Text myScore;
	// Use this for initialization
	void Start () {
		myScore = GetComponent<Text>();
		myScore.text = ScoreKeeper.score.ToString();
		ScoreKeeper.ResetScore();
	}

}
