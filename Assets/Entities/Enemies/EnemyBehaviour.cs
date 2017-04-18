using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
	public float health=150;
	public GameObject projectile;
	public float projectileSpeed;
	public float firingRate=0.5f;
	public float shotsPerSecond =0.5f;
	public int score =1000;
	private ScoreKeeper scoreKeeper;
	public AudioClip fireWeaponSoundEffect,enemyDeath;

	
	void Start(){
		scoreKeeper =GameObject.Find("Score").GetComponent<ScoreKeeper>();
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		Projectile missle = collider.gameObject.GetComponent<Projectile>();
			if(missle){
				health -=missle.GetDamage();
				missle.Hit();
				if(health<=0){
				scoreKeeper.ScorePoints(score);
					Die();
				}
				Debug.Log ("Enemy hit by a projectile");
			}
	}
	
	void Update(){
		float probability = Time.deltaTime*shotsPerSecond;
		if(Random.value<probability){
			fireWeapon();
		}
	}

	void fireWeapon(){
		GameObject fireBall =Instantiate(projectile,transform.position,Quaternion.identity) as GameObject;
		fireBall.rigidbody2D.velocity= new Vector3(0,-projectileSpeed,0);
		AudioSource.PlayClipAtPoint(fireWeaponSoundEffect,transform.position,1f);
	}
	
	void Die(){
		Destroy(gameObject);
		AudioSource.PlayClipAtPoint(enemyDeath,transform.position,2f);
	}
}
