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
	public houseExt house;

	float itemDroppingTimer = 3.2f;

	bool startingPosSetLR = false;
	bool startingPosSetRL = false;
	bool startingPosSetLRB = false;
    bool startingPosSetRLB = false;

    public bool leftToRightPlaying = false;
	public bool rightToLeftPlaying = false;
	public bool leftToRightBINDLEPlaying = false;
    public bool rightToLeftBINDLEPlaying = false;

    List<Vector3> leftToRightPoints;
	List<Vector3> leftToRightBINDLEPoints;
    List<Vector3> rightToLeftBINDLEPoints;

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
				house.changeToInt();
			}
			leftToRightPlaying=true;
			transform.position = Vector3.MoveTowards(this.transform.position, leftToRightPoints[1], Time.deltaTime*8f);
			
			if(transform.position == leftToRightPoints[1]){
				startingPosSetLR = false;
				leftToRightPlaying = false;
				house.changeToExt();
			}
		}
		
		if(Input.GetKey(KeyCode.K) || rightToLeftPlaying == true){
			if(startingPosSetRL == false){
				this.transform.position = leftToRightPoints[1];
				startingPosSetRL = true;
				transform.eulerAngles = new Vector2(0, 180);
				house.changeToInt();
			}
			rightToLeftPlaying=true;
			transform.position = Vector3.MoveTowards(this.transform.position, leftToRightPoints[0], Time.deltaTime*8f);
			
			
			if(transform.position == leftToRightPoints[0]){
				startingPosSetRL = false;
				rightToLeftPlaying = false;
				house.changeToExt();
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
				house.changeToInt();
			}
			if(transform.position.x < leftToRightBINDLEPoints[1].x){
				leftToRightBINDLEPlaying = true;
				transform.position = Vector3.MoveTowards(this.transform.position, leftToRightBINDLEPoints[1], Time.deltaTime*3f);
                animator.SetBool(charID + "Bindle", true);
			}
			if(transform.position == leftToRightBINDLEPoints[1]){
                animator.SetBool(charID + "Bindle", false);
                animator.SetBool(charID + "ItemDrop", true);
				itemDroppingTimer -= Time.deltaTime;
			}
			if(itemDroppingTimer < 0){
				itemDroppingTimer -= Time.deltaTime;
				animator.SetBool(charID + "ItemDrop", false);
				transform.position = Vector3.MoveTowards(this.transform.position, leftToRightBINDLEPoints[2], Time.deltaTime*3f);
			}
			if(transform.position == leftToRightBINDLEPoints[2]){
				itemDroppingTimer = 3.2f;
				startingPosSetLRB = false;
				leftToRightBINDLEPlaying = false;
				house.changeToExt();
			}
		}

        if (Input.GetKey(KeyCode.M) || rightToLeftBINDLEPlaying == true)
        {
            if (startingPosSetRLB == false)
            {
                this.transform.position = rightToLeftBINDLEPoints[0];
                startingPosSetRLB = true;
                transform.eulerAngles = new Vector2(0, 180);
				house.changeToInt();
            }
            if (transform.position.x > rightToLeftBINDLEPoints[1].x)
            {
                rightToLeftBINDLEPlaying = true;
                transform.position = Vector3.MoveTowards(this.transform.position, rightToLeftBINDLEPoints[1], Time.deltaTime * 3f);
                animator.SetBool(charID + "Bindle", true);
            }
            if (transform.position == rightToLeftBINDLEPoints[1])
            {
                animator.SetBool(charID + "Bindle", false);
                animator.SetBool(charID + "ItemDrop", true);
                itemDroppingTimer -= Time.deltaTime;
            }
            if (itemDroppingTimer < 0)
            {
                itemDroppingTimer -= Time.deltaTime;
                animator.SetBool(charID + "ItemDrop", false);
                transform.position = Vector3.MoveTowards(this.transform.position, rightToLeftBINDLEPoints[2], Time.deltaTime * 3f);
            }
            if (transform.position == rightToLeftBINDLEPoints[2])
            {
                itemDroppingTimer = 3.2f;
                startingPosSetLRB = false;
                rightToLeftBINDLEPlaying = false;
				house.changeToExt();
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
		leftToRightPoints.Add (new Vector3 (-8f, -6.3f, 0f));
		leftToRightPoints.Add (new Vector3 (8f, -6.3f, 0f));

		leftToRightBINDLEPoints = new List<Vector3> ();
		leftToRightBINDLEPoints.Add(new Vector3 (-8f, -6.3f, 0f));
		leftToRightBINDLEPoints.Add(new Vector3 (-1.6f, -6.3f, 0f));
		leftToRightBINDLEPoints.Add (new Vector3 (8f, -6.3f, 0f));

        rightToLeftBINDLEPoints = new List<Vector3>();
        rightToLeftBINDLEPoints.Add(new Vector3(8f, -6.3f, 0f));
        rightToLeftBINDLEPoints.Add(new Vector3(1.6f, -6.3f, 0f));
        rightToLeftBINDLEPoints.Add(new Vector3(-8f, -6.3f, 0f));
    }


}
