using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CallingCharAnimations : MonoBehaviour {

	public List<GameObject> characters;
	public List<GameObject> sleepingCharacters;
    

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
                character.resetAni();
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

	public void callAnimationWithItem(string charName, string side, string item){
        foreach (GameObject characterObj in characters)
        {
            Character character = characterObj.GetComponent<Character>();
            Debug.Log("Trying to animate " + character.name + " from the data: " + charName + " with: " + item);


            if (charName.Contains(character.name))
            {
                character.resetAni();
                character.currentItem = item;
                Debug.Log("it contains!s");
                if (side.Contains("right"))
                {
                    character.rightToLeftBINDLEPlaying = true;
                    Debug.Log("Right");
                }
                else if (side.Contains("left"))
                {
                    character.leftToRightBINDLEPlaying = true;
                    Debug.Log("Left");
                }
            }
        }
    }


	public void sleepingAnimations(string first, string second, string third, string fourth){
		foreach (GameObject character in sleepingCharacters) {
			SleepingChar sleepChar = character.GetComponent<SleepingChar> ();
			int ranking = 5;

			//0,1,2,3 for conversion to match with an array

			if (first.Contains (sleepChar.charID))
				ranking = 0;
			else if (second.Contains (sleepChar.charID))
				ranking = 1;
			else if (third.Contains (sleepChar.charID))
				ranking = 2;
			else if (fourth.Contains (sleepChar.charID))
				ranking = 3;
			
			sleepChar.goSleeping (ranking);
		}
	}
}
