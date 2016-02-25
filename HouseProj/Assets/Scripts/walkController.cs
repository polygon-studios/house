using UnityEngine;
using System.Collections;

public class walkController : MonoBehaviour {
	public float speed = 1.5f;
	Animator animator; //reference to the animator
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		//animator.SetFloat("moveSpeed", Mathf.Abs(Input.GetAxis("Horizontal"))); //set the move speed
		
		if (Input.GetAxisRaw ("Horizontal") > 0) { //moving character right
			Debug.Log("HERE");
			transform.Translate (speed * Time.deltaTime, 0.0f, 0.0f);
			transform.eulerAngles = new Vector2 (0, 0);
		}
		
		if (Input.GetAxisRaw ("Horizontal") < 0) {//move character left
			transform.Translate(speed * Time.deltaTime, 0.0f, 0.0f);
			transform.eulerAngles = new Vector2(0, 180);
		}

		/*if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Translate (speed * Time.deltaTime, 0.0f, 0.0f);
			transform.eulerAngles = new Vector2 (0, 0);
		}
		if(Input.GetKey(KeyCode.LeftArrow)){
			transform.Translate(speed * Time.deltaTime, 0.0f, 0.0f);
			transform.eulerAngles = new Vector2(0, 180);
		}
	*/
	}
}
