using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemyPrefab;
	public float width =10f;
	public float height = 5f;
	
	public float speed=10.0f;
		
	private bool movingRight = false;
	private float xMax;
	private float xMin;

	// Use this for initialization
	void Start () {
		float distanceToCamera = transform.position.z-Camera.main.transform.position.z;
		Vector3 leftBoundary =Camera.main.ViewportToWorldPoint(new Vector3(0,0,distanceToCamera));
	    Vector3 rightBoundary =Camera.main.ViewportToWorldPoint(new Vector3(1,0,distanceToCamera));
		xMax =rightBoundary.x; 
		xMin = leftBoundary.x;   
		                                              
		foreach(Transform child in transform){
			GameObject enemy =Instantiate(enemyPrefab,child.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(movingRight){
			transform.position+=Vector3.right*speed*Time.deltaTime; //new Vector3(speed*Time.deltaTime,0);
		}else{
			transform.position+= Vector3.left*speed*Time.deltaTime; //new Vector3(-speed*Time.deltaTime,0);
		}
		float rightEdgeFormation = transform.position.x+(0.4f*width);
		float leftEdgeFormation = transform.position.x-(0.4f*width);	
		
		if(leftEdgeFormation<xMin){
			movingRight=true;
		}else if(rightEdgeFormation>xMax){
			movingRight=false;
		}
	}
	
	public void OnDrawGizmos(){
		Gizmos.DrawWireCube(transform.position,new Vector3(width,height));
	}
}
