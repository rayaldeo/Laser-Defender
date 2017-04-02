﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed=5.0f;
	public float padding =1f;
	public float xMin;
	public float xMax;
	public GameObject projectile;
	public float projectileSpeed;
	public float firingRate=0.5f;

	// Use this for initialization
	void Start () {
		float distance = transform.position.z-Camera.main.transform.position.z;
		Vector3 leftMost =Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 rightMost =Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
		xMin = leftMost.x+padding;
		xMax=rightMost.x-padding;
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
		GameObject fireBall =Instantiate(projectile,transform.position,Quaternion.Euler(new Vector3(0f,0f,-90f))) as GameObject;
		fireBall.rigidbody2D.velocity= new Vector3(0,projectileSpeed,0);
	}
}
