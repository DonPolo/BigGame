using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTrue : MonoBehaviour {

	public float speed = 1.0f;

	private Rigidbody2D body;

	public bool isGrounded = false;

	public GameObject[] hearts;

	private int heartNb = 3;

	private bool canDied = true;

	public Scrollbar lifeBar;

	private int lifePoints = 100;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxis ("Horizontal");

		Vector2 move = new Vector2 (h, 0);

		if (Input.GetButtonDown ("Jump") && isGrounded) {
			move.y += 35;
		}

		if (h == 0) {
			body.velocity = new Vector2 (0, body.velocity.y);
		}

		body.AddForce (move * speed * Time.deltaTime);
	}

	public void getDam(int da){
		lifePoints -= da;
		lifeBar.size = (float)lifePoints / 100;
		if (lifePoints <= 0) {
			if (heartNb - 1 >= 0 && canDied) {
				hearts [heartNb - 1].SetActive (false);
				heartNb--;	
				canDied = false;
				StartCoroutine (waitDied ());
			}
		}
	}

	IEnumerator waitDied(){
		yield return new WaitForSeconds (1);
		canDied = true;
	}
}
