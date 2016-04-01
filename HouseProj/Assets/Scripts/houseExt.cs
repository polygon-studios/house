using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class houseExt : MonoBehaviour {

    public List<GameObject> characters;
	public List<GameObject> jailbars;
	public List<GameObject> nightHouse;
	public List<GameObject> dayHouse;
    public GameObject darkExt;
    public GameObject darkInt;
    public GameObject interior;
	public Door doorLeft;
	public Door doorRight;
    SpriteRenderer spriteRenderer;

    bool isDark;
	public bool isInHouse;
    GameObject currentExt;
    GameObject currentInt;

	//jail
	float jailTimer = 7;
	bool jailActive = false;

	// Use this for initialization
	void Start () {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();

        currentExt = this.gameObject;
        currentInt = interior;

		foreach (GameObject darkObj in nightHouse) {
			darkObj.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
		}
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.K)){
            spriteRenderer.color = new Color(1f, 1f, 1f, 0f);//hide day centre house
		}
		if(Input.GetKey(KeyCode.L)){
            spriteRenderer.color = new Color(1f, 1f, 1f, 1f);//show day centre house
		}
        if (Input.GetKey(KeyCode.D))
        {
            goDark();
        }

        bool isStillInside = false;

        foreach (GameObject charObj in characters)
        {
            if (charObj.gameObject.GetComponent<Character>().isInHouse == true)
                isStillInside = true;
        }

        if (isStillInside == false)
            changeToExt();
        else
            changeToInt();

		if (Input.GetKey (KeyCode.J) || jailActive == true) {
			showJailBars ();
		}
    }

    public void goDark()
    {
        isDark = true;
        spriteRenderer.color = new Color(1f, 1f, 1f, 0f);

		Animator doorLeftAni =  doorLeft.gameObject.GetComponent<Animator> ();
		Animator doorRightAni = doorRight.gameObject.GetComponent<Animator> ();
		doorLeftAni.SetTrigger ("night");
		doorRightAni.SetTrigger ("night");

		foreach (GameObject darkObj in nightHouse) {
			darkObj.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f,1f);
		}

        spriteRenderer = darkExt.gameObject.GetComponent<SpriteRenderer>();
        interior.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
    }
    
	void changeToInt(){
        spriteRenderer.color = new Color(1f, 1f, 1f, 0f);
	}

	void changeToExt(){
            spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
	}

    public void showJailBars()
    {

		foreach (GameObject bar in jailbars) {

			Animator jailAnimator = bar.GetComponent<Animator> ();
			jailAnimator.SetBool ("jailBarsOut", false);
			jailAnimator.SetBool ("jailBarsIn", true);
		}

		jailActive = true;
		jailTimer -= Time.deltaTime;

		if (jailTimer < 0)
			hideJailBars ();

    }

    void hideJailBars()
    {
		foreach (GameObject bar in jailbars) {
		
			Animator jailAnimator = bar.GetComponent<Animator> ();
			jailAnimator.SetBool ("jailBarsIn", false);
			jailAnimator.SetBool ("jailBarsOut", true);
		}

		jailTimer = 7;
		jailActive = false;
    }
}
