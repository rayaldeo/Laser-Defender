using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	 static MusicPlayer instance = null;
	 
	 
	 void Awake(){
	 	//Debug.Log ("Music plyer Awaked: " + GetInstanceID());
		if(instance !=null){
			Destroy (gameObject);
			print ("Duplicate music player:self-destructing");
		}else{
			instance=this;
			GameObject.DontDestroyOnLoad(gameObject);//This Command is used to keep music playing throughout differnt scenes
		}
	 }

	// Use this for initialization
	void Start () {
		//Debug.Log ("Music plyer Start: " + GetInstanceID());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
