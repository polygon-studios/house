using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CallingCharAnimations : MonoBehaviour {

	public List<GameObject> characters;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void callAnimation(string charName, string side){
		foreach (GameObject characterObj in characters) {
			Character character = characterObj.GetComponent<Character>();
			Debug.Log("Trying to animate " + character.name + " from the data: " + charName);


			if(charName.Contains (character.name)){
				Debug.Log("it contains!s");
				if(side.Contains("right")){
					character.rightToLeftPlaying = true;
					
					Debug.Log("Right");
				}else if (side.Contains("left")){
					character.leftToRightPlaying = true;
					Debug.Log("Left");
				}
			}
		}
	}

	public void callAnimationWithItem(string charName, string side, string item, string itemName){

	}
}
