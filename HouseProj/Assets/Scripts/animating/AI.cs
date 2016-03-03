/*
 * Developer: Tegan Scott
 * Date: November 16, 2015
 * Class: IMD 4902, Carleton University
 * 
 * Purpose: The AI to have the character move to the next wayoint in he environment. THIS IS A COPY OF THE CLASS USED IN THE TUTORIAL! 
 * 
 * */


using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {

	public GameObject[] waypoints; //the collection of waypoints. Drag and drop waypoints from the hierarchy into this item in the inspector window.
	public int _activeWaypoint = 0; //the current waypoint the AI will move towards
	private Vector3 target; //the position to move towards
	
	public float speed; //the distance per step towards a waypoint. Higher is faster.

	// Use this for initialization
	void Start () {
		GetHeading(); //look towards the first waypoint
	}
	
	// Update is called once per frame
	void Update () {
		//move towards the target position until it reaches the target position, by *speed* steps per frame.
		transform.position = Vector3.MoveTowards(transform.position, target, speed);

	}
	
	//look at the current waypoint and get the position to look at.
	void GetHeading(){
		target = waypoints[_activeWaypoint].transform.position; //get the current waypoints posiiton.
		//target.y = transform.position.y; //We want the AI to always be looking straight ahead, so we use this object's y (height) value.
		transform.LookAt(target); //rotate this object twards the target position.
	}
	
	public void NextWaypoint(){
		_activeWaypoint ++; //increment the active waypoint.
		if(_activeWaypoint >= waypoints.Length) //if the number is beyond the number of waypoints, start from the first one again.
			_activeWaypoint = 0;
		
		GetHeading(); //look towards the new waypoint
	}
	
	/* Don't add until UT-3D-3 Part 3.*/
	public void Die(){
		Destroy(this.gameObject); //this will remove the gameobject attached to this script and handle garbage collection.
	}
	/**/
}
