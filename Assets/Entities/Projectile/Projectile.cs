using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public int damage = 100;
	
	public void Hit(){
		Destroy (gameObject);
	}
	
	public int GetDamage(){
		return damage;
	}
}
