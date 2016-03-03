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

	public void callAnimation(string charName, float side){
		foreach (GameObject characterObj in characters) {
			Character character = characterObj.GetComponent<Character>();
			if(character.charID.Contains (charName)){
				if(side == 1){
					character.rightToLeftPlaying = true;
				}else if (side == 2){
					character.leftToRightPlaying = true;
				}
			}
		}
	}

	public void callAnimationWithItem(string charName, float side, string item, string itemName){

	}
}
