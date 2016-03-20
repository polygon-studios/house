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

    //itemAnimations
    public GameObject slippersPrefab;
    public GameObject chiliPrefab;
    public GameObject pinwheelPrefab;
    public GameObject prunePrefab;
    public GameObject treasurePrefab;
    public GameObject fireworkPrefab;
    public GameObject oilPrefab;
    public GameObject fishPrefab;
    public GameObject ghostPrefab;
    GameObject currentItemObj;
    public string currentItem;

    //moving and playing animations
    float savedItemDropperTimer = 3.2f;
	float itemDroppingTimer = 3.2f;
    bool itemDropAniPlaying = false;

    bool startingPosSetLR = false;
	bool startingPosSetRL = false;
	bool startingPosSetLRB = false;
    bool startingPosSetRLB = false;

    public bool leftToRightPlaying = false;
	public bool rightToLeftPlaying = false;
	public bool leftToRightBINDLEPlaying = false;
    public bool rightToLeftBINDLEPlaying = false;

    public bool isInHouse;

    List<Vector3> leftToRightPoints;
	List<Vector3> leftToRightBINDLEPoints;
    List<Vector3> rightToLeftBINDLEPoints;

    Animator animator;
	public float speed; //walk 0.5f //run 0.8f


	// Use this for initialization
	void Start () {
		animator = this.gameObject.GetComponent<Animator> ();
		updateAnimationPoints ();
        savedItemDropperTimer = itemDroppingTimer;
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
                isInHouse = true;
				
			}
			leftToRightPlaying=true;
			transform.position = Vector3.MoveTowards(this.transform.position, leftToRightPoints[1], Time.deltaTime*8f);
			
			if(transform.position == leftToRightPoints[1]){
                isInHouse = false;
                resetAni();
            }
		}
		
		if(Input.GetKey(KeyCode.K) || rightToLeftPlaying == true){
			if(startingPosSetRL == false){
				this.transform.position = leftToRightPoints[1];
				startingPosSetRL = true;
				transform.eulerAngles = new Vector2(0, 180);
                isInHouse = true;
            }
			rightToLeftPlaying=true;
			transform.position = Vector3.MoveTowards(this.transform.position, leftToRightPoints[0], Time.deltaTime*8f);
			
			
			if(transform.position == leftToRightPoints[0]){
                isInHouse = false;
                resetAni();
			}
		}
	}

	void Movement(){
		animator.SetFloat (charID + "MoveSpeed", Mathf.Abs (Input.GetAxis ("Horizontal")));
       


		if (Input.GetKey (KeyCode.N) || leftToRightBINDLEPlaying == true) {
            
			if(startingPosSetLRB == false){
				this.transform.position = leftToRightBINDLEPoints[0];
				startingPosSetLRB = true;
				transform.eulerAngles = new Vector2 (0, 0);
                isInHouse = true;
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

                //play animation
                if (itemDropAniPlaying == false)
                {
                    playItemDrop(true);
                    itemDropAniPlaying = true;
                }
			}
			if(itemDroppingTimer < 0){
				itemDroppingTimer -= Time.deltaTime;
				animator.SetBool(charID + "ItemDrop", false);
				transform.position = Vector3.MoveTowards(this.transform.position, leftToRightBINDLEPoints[2], Time.deltaTime*3f);
			}
			if(transform.position == leftToRightBINDLEPoints[2]){
                isInHouse = false;
                resetAni();

                if(currentItemObj != null)
                {
                    Destroy(currentItemObj);
                }
			}
		}

        if (Input.GetKey(KeyCode.M) || rightToLeftBINDLEPlaying == true)
        {
            if (startingPosSetRLB == false)
            {
                this.transform.position = rightToLeftBINDLEPoints[0];
                startingPosSetRLB = true;
                transform.eulerAngles = new Vector2(0, 180);
                isInHouse = true;
                Debug.Log("HERE");
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

                //play animation
                if (itemDropAniPlaying == false)
                {
                    playItemDrop(false);
                    itemDropAniPlaying = true;
                }
            }
            if (itemDroppingTimer < 0)
            {
                itemDroppingTimer -= Time.deltaTime;
                animator.SetBool(charID + "ItemDrop", false);
                transform.position = Vector3.MoveTowards(this.transform.position, rightToLeftBINDLEPoints[2], Time.deltaTime * 3f);
            }
            if (transform.position == rightToLeftBINDLEPoints[2])
            {
                isInHouse = false;
                resetAni();

                if (currentItemObj != null)
                {
                    Destroy(currentItemObj);
                }
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

    public void resetAni()
    {
        leftToRightBINDLEPlaying = false;
        rightToLeftBINDLEPlaying = false;
        leftToRightPlaying = false;
        rightToLeftPlaying = false;
       // Vector3 resetPos = new Vector3(leftToRightPoints[0].x, leftToRightPoints[0].y, )
        transform.position = leftToRightPoints[0];

        startingPosSetLR = false;
        startingPosSetRL = false;
        startingPosSetRLB = false;
        startingPosSetLRB = false;
        isInHouse = false;
        itemDroppingTimer = savedItemDropperTimer;
        itemDropAniPlaying = false;

        /*if (currentItemObj != null)
        {
            Destroy(currentItemObj);
        }*/

    }

    void playItemDrop(bool isLeft)
    {
        Vector3 itemPos;
        if (isLeft == true)
            itemPos = new Vector3(-0.9f, -4.84f, 0);
        else {
            itemPos = new Vector3(1.3f, -4.84f, 0);
            
        }

        if (currentItem.Contains("slippers"))
            currentItemObj = (GameObject)Instantiate(slippersPrefab, itemPos, Quaternion.identity);
        else if(currentItem.Contains("chili"))
            currentItemObj = (GameObject)Instantiate(chiliPrefab, itemPos, Quaternion.identity);
        else if(currentItem.Contains("treasure"))
            currentItemObj = (GameObject)Instantiate(treasurePrefab, itemPos, Quaternion.identity);
        else if(currentItem.Contains("firework"))
            currentItemObj = (GameObject)Instantiate(fireworkPrefab, itemPos, Quaternion.identity);
        else if(currentItem.Contains("ghost"))
            currentItemObj = (GameObject)Instantiate(ghostPrefab, itemPos, Quaternion.identity);
        else if(currentItem.Contains("oil"))
            currentItemObj = (GameObject)Instantiate(oilPrefab, itemPos, Quaternion.identity);
        else if(currentItem.Contains("pinwheel"))
            currentItemObj = (GameObject)Instantiate(pinwheelPrefab, itemPos, Quaternion.identity);
        else if (currentItem.Contains("fish"))
            currentItemObj = (GameObject)Instantiate(fishPrefab, itemPos, Quaternion.identity);
        else 
            currentItemObj = (GameObject)Instantiate(prunePrefab, itemPos, Quaternion.identity);
        
        if(isLeft == true)
            currentItemObj.transform.eulerAngles = new Vector2(0, 0);
        else
            currentItemObj.transform.eulerAngles = new Vector2(0, 180);
    }

    void playItemDropRight()
    {
        currentItemObj = (GameObject)Instantiate(slippersPrefab, new Vector3(0.76f, -6.18f, 0), Quaternion.identity);
        currentItemObj.transform.eulerAngles = new Vector2(0, 180);
    }

	void updateAnimationPoints(){
		leftToRightPoints = new List<Vector3> ();
		leftToRightPoints.Add (new Vector3 (-8f, -6.3f, 0f));
		leftToRightPoints.Add (new Vector3 (8.5f, -6.3f, 0f));

		leftToRightBINDLEPoints = new List<Vector3> ();
		leftToRightBINDLEPoints.Add(new Vector3 (-8f, -6.3f, 0f));
		leftToRightBINDLEPoints.Add(new Vector3 (-1.6f, -6.3f, 0f));
		leftToRightBINDLEPoints.Add (new Vector3 (8.5f, -6.3f, 0f));

        rightToLeftBINDLEPoints = new List<Vector3>();
        rightToLeftBINDLEPoints.Add(new Vector3(8.5f, -6.3f, 0f));
        rightToLeftBINDLEPoints.Add(new Vector3(2.1f, -6.3f, 0f));
        rightToLeftBINDLEPoints.Add(new Vector3(-8f, -6.3f, 0f));
    }


}
