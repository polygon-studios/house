using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	public bool onGround = false;

	public void isOnGround(bool passThrough){
		onGround = passThrough;
	}
	public KeyCode inputLeft;
	public KeyCode inputRight;
	

	Animator animator;
	public float speed; //walk 0.5f //run 0.8f


	// Use this for initialization
	void Start () {
		animator = this.gameObject.GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
		Movement ();
	}

	void Movement(){
		/*
		A button used to jump
		X button used for picking up, activating, and using items
		B button used to drop items
		*/

		animator.SetFloat ("foxMoveSpeed", Mathf.Abs (Input.GetAxis ("Horizontal")));
       

		if (Input.GetKey (inputRight)) { //moving character right
			transform.Translate (speed * Time.deltaTime, 0.0f, 0.0f);
			transform.eulerAngles = new Vector2 (0, 0);
		}
		
		if (Input.GetKey (inputLeft)) {//move character left
			transform.Translate(speed * Time.deltaTime, 0.0f, 0.0f);
			transform.eulerAngles = new Vector2(0, 180);
		}
	}


}
