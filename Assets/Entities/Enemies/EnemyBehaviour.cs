using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
	public float health=150;
	public GameObject projectile;
	public float projectileSpeed;
	public float firingRate=0.5f;
	public float shotsPerSecond =0.5f;

	
	void OnTriggerEnter2D(Collider2D collider){
		Projectile missle = collider.gameObject.GetComponent<Projectile>();
		if(missle){
			health -=missle.GetDamage();
			missle.Hit();
			if(health<=0){
				Destroy(gameObject);
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
		Vector3 startPosition = transform.position+ new Vector3(0f,-0.1f,0f);
		GameObject fireBall =Instantiate(projectile,startPosition,Quaternion.identity) as GameObject;
		fireBall.rigidbody2D.velocity= new Vector3(0,-projectileSpeed,0);
	}
}
