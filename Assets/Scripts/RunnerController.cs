using UnityEngine;
using System.Collections;

public class RunnerController : MonoBehaviour {

	public float jumpForce = 500f;

	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonUp ("Jump")) {
			rb2d.AddForce(transform.up * jumpForce);
		}
	}
}
