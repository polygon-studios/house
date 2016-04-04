using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SleepingChar : MonoBehaviour {

	//public List<Vector2> sleepingLocation;
	public Vector2[] sleepingLocation2;
	//public ArrayList<Vector2> sleepingLocation2;
	public string charID;
	public bool isInHouse = false;
	int winPos = 0;


	// Use this for initialization
	void Start () {
		SpriteRenderer spriteRenderer = this.gameObject.GetComponent<SpriteRenderer> ();
		spriteRenderer.color = new Color(1f, 1f, 1f, 0f);
	}

    // Update is called once per frame
    void Update() {
        if (winPos < sleepingLocation2.Length) { 
        Vector3 pos = new Vector3(sleepingLocation2[winPos].x, sleepingLocation2[winPos].y, transform.position.z);
    

		transform.position = pos;
        }
    }

	public void goSleeping(int winPosSet){
		winPos = winPosSet;
		if (winPos < 4) {
			
			isInHouse = true;
			SpriteRenderer spriteRenderer = this.gameObject.GetComponent<SpriteRenderer> ();
			spriteRenderer.color = new Color (1f, 1f, 1f, 1f);

			Vector3 pos = new Vector3 (sleepingLocation2 [winPos].x, sleepingLocation2 [winPos].y, transform.position.z);

			transform.position = pos;
		}
	}
}
