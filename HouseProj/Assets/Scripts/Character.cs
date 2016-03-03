using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Character : MonoBehaviour {
	public bool onGround = false;

	public void isOnGround(bool passThrough){
		onGround = passThrough;
	}
	public KeyCode inputLeft;
	public KeyCode inputRight;
	public string charID;

	float itemDroppingTimer = 10;

	bool startingPosSetLR = false;
	bool startingPosSetRL = false;
	bool startingPosSetLRB = false;

	public bool leftToRightPlaying = false;
	public bool rightToLeftPlaying = false;
	public bool leftToRightBINDLEPlaying = false;

	List<Vector3> leftToRightPoints;
	List<Vector3> leftToRightBINDLEPoints;

	Animator animator;
	public float speed; //walk 0.5f //run 0.8f


	// Use this for initialization
	void Start () {
		animator = this.gameObject.GetComponent<Animator> ();
		updateAnimationPoints ();
	}
	
	// Update is called once per frame
	void Update () {
		Movement ();
		Animations ();
	}

	void Animations (){

		if(Input.GetKey(KeyCode.J) || leftToRightPlaying == true){
			if(startingPosSetLR == false){
				this.transform.position = leftToRightPoints[0];
				startingPosSetLR = true;
				transform.eulerAngles = new Vector2(0, 0);
			}
			leftToRightPlaying=true;
			transform.position = Vector3.MoveTowards(this.transform.position, leftToRightPoints[1], Time.deltaTime*8f);
			
			if(transform.position == leftToRightPoints[1]){
				startingPosSetLR = false;
				leftToRightPlaying = false;
			}
		}
		
		if(Input.GetKey(KeyCode.K) || rightToLeftPlaying == true){
			if(startingPosSetRL == false){
				this.transform.position = leftToRightPoints[1];
				startingPosSetRL = true;
				transform.eulerAngles = new Vector2(0, 180);
			}
			rightToLeftPlaying=true;
			transform.position = Vector3.MoveTowards(this.transform.position, leftToRightPoints[0], Time.deltaTime*8f);
			
			
			if(transform.position == leftToRightPoints[0]){
				startingPosSetRL = false;
				rightToLeftPlaying = false;
			}
		}
	}

	void Movement(){
		animator.SetFloat ("foxMoveSpeed", Mathf.Abs (Input.GetAxis ("Horizontal")));
       


		if (Input.GetKey (KeyCode.N) || leftToRightBINDLEPlaying == true) {
			if(startingPosSetLRB == false){
				this.transform.position = leftToRightBINDLEPoints[0];
				startingPosSetLRB = true;
				transform.eulerAngles = new Vector2 (0, 0);
			}
			if(transform.position.x < leftToRightBINDLEPoints[1].x){
				leftToRightBINDLEPlaying = true;
				transform.position = Vector3.MoveTowards(this.transform.position, leftToRightBINDLEPoints[1], Time.deltaTime*8f);
			}
			if(transform.position == leftToRightBINDLEPoints[1]){
				animator.SetBool(charID + "ItemDrop", true);
				itemDroppingTimer -= Time.deltaTime;
			}

			if(itemDroppingTimer < 0){
				itemDroppingTimer -= Time.deltaTime;
				animator.SetBool(charID + "ItemDrop", false);
				transform.position = Vector3.MoveTowards(this.transform.position, leftToRightBINDLEPoints[2], Time.deltaTime*8f);
			}

			if(transform.position == leftToRightBINDLEPoints[2]){
				itemDroppingTimer = 10;
				startingPosSetLRB = false;
				leftToRightBINDLEPlaying = false;
			}
		}


		/*if (Input.GetKey (inputRight)) { //moving character right
			transform.Translate (speed * Time.deltaTime, 0.0f, 0.0f);
			transform.eulerAngles = new Vector2 (0, 0);
		}
		
		if (Input.GetKey (inputLeft)) {//move character left
			transform.Translate(speed * Time.deltaTime, 0.0f, 0.0f);
			transform.eulerAngles = new Vector2(0, 180);
		}*/
	}

	void updateAnimationPoints(){
		leftToRightPoints = new List<Vector3> ();
		leftToRightPoints.Add (new Vector3 (-21f, -17f, 0f));
		leftToRightPoints.Add (new Vector3 (21.85f, -17f, 0f));

		leftToRightBINDLEPoints = new List<Vector3> ();
		leftToRightBINDLEPoints.Add(new Vector3 (-21f, -17f, 0f));
		leftToRightBINDLEPoints.Add(new Vector3 (-4.2f, -17f, 0f));
		leftToRightBINDLEPoints.Add (new Vector3 (21.85f, -17f, 0f));
	}


}
