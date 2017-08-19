using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour {
	private Transform transform;

	public float lWidth_izq;
	public float lWidth_der;
	public float lHeight_up;
	public float lHeight_down;
	private bool up=false;
	private bool down=false;
	private bool left=false;
	private bool right=false;

	private bool faceUp=false;
	private bool limite=false;

	// Use this for initialization
	void Awake () {
		
		transform=GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		up=BoundUp();
		down=BoundDown();
		right=BoundRight();
		left=BoundLeft();
		limite=ActiveLimit();

	}
	private bool BoundUp(){
		
		if(transform.position.z>lHeight_up){
			print("limite up");
			limite=true;
			faceUp=GetFaceUp("up");
			return true;
			}
		limite=false;
		return false;
	}
	private bool BoundDown(){
		if(transform.position.z<lHeight_down){
		//	print("limite down!");
			limite=true;
			faceUp=GetFaceUp("down");
		
			return true;
		}
		return false;
	}
	private bool BoundRight(){
		if(transform.position.x>lWidth_der){
			print("limite right");
			limite=true;
			faceUp=GetFaceUp("right");
			return true;
		}
		return false;
	}
	private bool BoundLeft(){
		if(transform.position.x<lWidth_izq){
			print("limite left");

			faceUp=GetFaceUp("left");
			return true;

		}
		return false;

	}
	private bool ActiveLimit(){
		if(up==false&&down==false&&right==false&&left==false){
			return false;
		}else{
			print("limite activo");
			return true;
		}
		return false;
	}
	private bool GetFaceUp(string currentLimite){
		switch(currentLimite){
		case "up":
			if(transform.eulerAngles.y<90||transform.transform.eulerAngles.y>270){
				print("face up  true");
				return true;
			}else{
				print("face up  false");
				return false;

			}
			break;
	
		case "down":
			if(transform.eulerAngles.y>90&&transform.eulerAngles.y<270){
				print("face up down true");	
				return true;
			}else{
				print("face up down false");
				return false;
			}	
			break;
		case "left":
			if(transform.eulerAngles.y>180){
				print("face up left true");
				return true;
			}else{
				print("face up left false");
				return false;
			}
			break;
		
		case "right":
			
			if(transform.eulerAngles.y<180){
				print("face up right true");
				return true;
			}else{
				print("face up right false");
				return false;
			}
			break;
		}


		return false;
	}
	public bool limiteActive{
		get {
			return limite;
		}
	}
	public bool getFaceUp{
		//obtiene si esta mirando para arriba
		get{
			return faceUp;
		}
	}

}

