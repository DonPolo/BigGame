using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour {

	public enum type {mine, pics};

	public type TrapType;

	public int dammages;

	private bool kill = false;
	private GameObject player;

	private bool canKill = true;


	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Player" && canKill) {
			switch (TrapType) {
			case type.mine:
				col.gameObject.SendMessage ("getDam", dammages);
				Destroy (gameObject);
				break;
			case type.pics:
				canKill = false;
				kill = true;
				player = col.gameObject;
				col.gameObject.SendMessage ("getDam", dammages);
				StartCoroutine (waitKill ());
				StartCoroutine (wait ());
				break;
			}
		}
	}

	void OnCollisionExit2D(Collision2D col){
		if (col.gameObject.tag == "Player") {
			switch (TrapType) {
			case type.pics:
				canKill = false;
				kill = false;
				break;
			}
		}
	}

	IEnumerator waitKill(){
		yield return new WaitForSeconds (1);
		canKill = true;
	}

	IEnumerator wait(){
		yield return new WaitForSeconds (1);
		player.gameObject.SendMessage ("getDam", dammages);
		if (kill) {
			StartCoroutine (wait ());
		}
	}

}

