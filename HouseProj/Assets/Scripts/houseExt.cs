using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class houseExt : MonoBehaviour {

    public List<GameObject> characters;
    public GameObject jailbars;
	public GameObject jailbarsSideLeft;
	public GameObject jailbarsSideRight;
    public GameObject darkExt;
    public GameObject darkInt;
    public GameObject interior;
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
        darkInt.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        darkExt.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.K)){
            spriteRenderer.color = new Color(1f, 1f, 1f, 0f);
		}
		if(Input.GetKey(KeyCode.L)){
            spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
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
		/*foreach (GameObject sleepingChar in sleepinCharacters)
		{
			if (charObj.gameObject.GetComponent<Character>().isInHouse == true)
				isStillInside = true;
		}*/

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
        spriteRenderer = darkExt.gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
        darkInt.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
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
		Animator jailAnimator = jailbars.GetComponent<Animator> ();
		jailAnimator.SetBool ("jailBarsOut", false);
		jailAnimator.SetBool ("jailBarsIn", true);

		jailActive = true;
		jailTimer -= Time.deltaTime;

		if (jailTimer < 0)
			hideJailBars ();
        //jailbars.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);

    }

    void hideJailBars()
    {
		jailActive = false;
		Animator jailAnimator = jailbars.GetComponent<Animator> ();
		jailAnimator.SetBool ("jailBarsIn", false);
		jailAnimator.SetBool ("jailBarsOut", true);

		jailTimer = 7;
        //jailbars.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
    }
}
