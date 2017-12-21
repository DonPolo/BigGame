using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideFeet : MonoBehaviour {

	private PlayerTrue pla;

	void Start(){
		pla = transform.parent.GetComponent<PlayerTrue> ();
	}

	void OnCollisionEnter2D(Collision2D other){
		print ("ground");
		if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Dead") {
			pla.isGrounded = true;
		}
	}

	void OnCollisionExit2D(Collision2D other){
		if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Dead") {
			pla.isGrounded = false;
		}
	}
}
