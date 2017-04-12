using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed=5.0f;
	public float padding =1f;
	public float xMin;
	public float xMax;
	public GameObject projectile;
	public float projectileSpeed;
	public float firingRate=0.5f;
	public int health=2000;
	public ParticleSystem thrusters;
	private HealthKeeper healthKeeper;
	public AudioClip fireWeaponSound;
	private LevelManager levelManager;
	

	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		healthKeeper =GameObject.Find("Health").GetComponent<HealthKeeper>();
		float distance = transform.position.z-Camera.main.transform.position.z;
		Vector3 leftMost =Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 rightMost =Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
		xMin = leftMost.x+padding;
		xMax=rightMost.x-padding;
		IgniteThrusters();
		//Screen.showCursor = false;//Don't show the Cursor
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.S)){
			InvokeRepeating("fireWeapon",0.00001f,firingRate);
		}
		if(Input.GetKeyUp(KeyCode.S)){
			CancelInvoke("fireWeapon");
		}
		if(Input.GetKey(KeyCode.A)){
			transform.position+=Vector3.left*speed*Time.deltaTime;
		}else if(Input.GetKey(KeyCode.D)){
			transform.position+=Vector3.right*speed*Time.deltaTime;
		}
		//Restrict the player to the Game Space
		float newX = Mathf.Clamp(transform.position.x,xMin,xMax);
		transform.position= new Vector3(newX,transform.position.y,transform.position.z);
	}
	
	void fireWeapon(){
		Vector3 startPosition = transform.position+ new Vector3(0f,1,0f);
		GameObject fireBall =Instantiate(projectile,startPosition,Quaternion.Euler(new Vector3(0f,0f,-90f))) as GameObject;
		fireBall.rigidbody2D.velocity= new Vector3(0,projectileSpeed,0);
		AudioSource.PlayClipAtPoint(fireWeaponSound,transform.position,1f);
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		Projectile missle = collider.gameObject.GetComponent<Projectile>();
		if(missle){
			health -=missle.GetDamage();
			missle.Hit();
			if(health<=0){
				Destroy(gameObject);
				levelManager.LoadLevel("Lose");
			}
			healthKeeper.SetHealth(health);
			Debug.Log ("Player Ship hit by a projectile");
		}
		
	}
	void IgniteThrusters() {
		thrusters.Play(); // Continue normal emissions
	}
	
	public int GetCurrentHealth(){
		return health;
	}
}
