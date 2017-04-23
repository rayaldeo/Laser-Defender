using UnityEngine;
using System.Collections;

public class EnemyFormationController : MonoBehaviour {
	//public GameObject enemyPrefab,enemyPrefab01;
	public float width =10f;
	public float height = 5f;
	public float speed=10.0f;
	private bool movingRight = false;
	private float xMax;
	private float xMin;
	public float spawnDelay =0.5f;
	private int enemyIndex;
	public GameObject[] enemies;
	
	// Use this for initialization
	void Start () {
		float distanceToCamera = transform.position.z-Camera.main.transform.position.z;
		Vector3 leftBoundary =Camera.main.ViewportToWorldPoint(new Vector3(0,0,distanceToCamera));
		Vector3 rightBoundary =Camera.main.ViewportToWorldPoint(new Vector3(1,0,distanceToCamera));
		xMax =rightBoundary.x; 
		xMin = leftBoundary.x;  
		//SpawnEnemies();
		SpawnUntilFull();
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
		enemyIndex =Random.Range(0, 1);
		Debug.Log("This Enemy was chosen" + enemyIndex);
		if(AllMembersDead()){
			Debug.Log("Empty Formation");
			//SpawnEnemies();
			SpawnUntilFull();
		}
	}
	
	bool AllMembersDead(){
		foreach(Transform childPositionGameObject in transform){
			if(childPositionGameObject.childCount>0)
				return false;
		}
		return true;
	}
	
	void SpawnEnemies(){
		foreach(Transform child in transform){
			GameObject enemy =Instantiate(PickARandomEnemy(),child.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}
	}
	
	public void OnDrawGizmos(){
		Gizmos.DrawWireCube(transform.position,new Vector3(width,height));
	}
	
	public Transform NextFreePosition(){
		foreach(Transform childPositionGameObject in transform){
			if(childPositionGameObject.childCount == 0){
				return childPositionGameObject;
			}
		}
		return null;
	}
	
	void SpawnUntilFull(){
		Transform freePosition = NextFreePosition();
		if(freePosition){
			GameObject enemy =Instantiate(PickARandomEnemy(),freePosition.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = freePosition;
			Invoke ("SpawnUntilFull",spawnDelay);
			}
	}
	GameObject PickARandomEnemy(){
		//int enemyIndex=0;
		return enemies[enemyIndex];
		
		
	}
}
