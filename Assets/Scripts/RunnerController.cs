using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class RunnerController : MonoBehaviour {

	public float jumpForce = 500f;

	private Rigidbody2D rb2d;
	private Animator anim;
	private float runnerHurtTime = -1;
	private Collider2D collider;
	public Text scoreText;
	private float startTime;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();

		anim = GetComponent<Animator> ();

		collider = GetComponent<Collider2D> (); 

		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (runnerHurtTime == -1) {
			if (Input.GetButtonUp ("Jump")) {
				rb2d.AddForce (transform.up * jumpForce);
			}

			anim.SetFloat ("vVelocity", rb2d.velocity.y);
			scoreText.text = (Time.time - startTime).ToString ("0.0");
		} else {
			if (Time.time > runnerHurtTime + 2) {
				Application.LoadLevel (Application.loadedLevel);
			}	
		}
	}

	void OnCollisionEnter2D(Collision2D collision){
		if (collision.collider.gameObject.layer == LayerMask.NameToLayer ("Enemy")) {

			foreach (PrefabsSpawner spawner in FindObjectsOfType<PrefabsSpawner>()) {
				spawner.enabled = false;
			}

			foreach (MoveLeft moveLefter in FindObjectsOfType<MoveLeft>()) {
				moveLefter.enabled = false;
			}

			runnerHurtTime = Time.time;
			anim.SetBool ("Hurt", true);
			rb2d.velocity = Vector2.zero;
			rb2d.AddForce (transform.up * jumpForce);
			collider.enabled = false;
		}
	}
}
