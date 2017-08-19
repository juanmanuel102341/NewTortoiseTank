using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traslacion : MonoBehaviour {
	private Rigidbody objRigid;
	public float velocity;
	public float velocityRotation;
	// Use this for initialization
	private Bounds bounds;

	void Awake () {
		//objRigid=GetComponent<Rigidbody>();
		bounds=GetComponent<Bounds>();

	}
	void Update(){
		//print("euler "+transform.eulerAngles);
		if(Input.GetKey(KeyCode.A)){
		//	transform.Translate(Vector3.left*Time.deltaTime*velocity);
			transform.Rotate(Vector3.up*Time.deltaTime*-velocityRotation);
		}else if(Input.GetKey(KeyCode.D)){
			transform.Rotate(Vector3.up*Time.deltaTime*velocityRotation);
		}

		if(Input.GetKey(KeyCode.W)&&!bounds.limiteActive||bounds.limiteActive&&!bounds.getFaceUp&&Input.GetKey(KeyCode.W)){
			transform.Translate(Vector3.forward*Time.deltaTime*velocity);//movimiento foward relativo
		}else if(Input.GetKey(KeyCode.S)&&!bounds.limiteActive||bounds.limiteActive&&bounds.getFaceUp&&Input.GetKey(KeyCode.S)){
			transform.Translate(Vector3.back*Time.deltaTime*velocity);
		}


	}
	
	// Update is called once per frame

}
