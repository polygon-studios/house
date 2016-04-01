using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	Animator animator;

	// Use this for initialization
	void Start () {
		animator = this.gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void triggerDoorAni(){
		animator.SetTrigger ("doorOpen");
	}

	public void setNight(){
		animator.SetTrigger ("night");
	}
}
