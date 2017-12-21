using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	public float speed = 1.0f;

	public Text pointTxt;
	private int points = 0;

	public GameObject win;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float v = Input.GetAxis ("Vertical");
		float h = Input.GetAxis ("Horizontal");

		//transform.Translate(new Vector3(v, 0, -h) * speed * Time.deltaTime);

		GetComponent<Rigidbody> ().AddForce(new Vector3(v, 0 , -h) * speed * Time.deltaTime);

		//GetComponent<CharacterController> ().Move (new Vector3 (v, 0, -h) * speed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider other){
		print("collide");
		if (other.tag == "Takeable") {
			Destroy (other.gameObject);
			points++;
			pointTxt.text = points.ToString ();
			if (points >= 11) {
				//Win
				win.SetActive(true);
			}
		} else if (other.tag == "Dead") {
			SceneManager.LoadScene ("game");
		}
	}
}
