/*
 * Developer: Tegan Scott
 * Date: November 16, 2015
 * Class: IMD 4902, Carleton University
 * 
 * Purpose: On the waypoint objects to send them to the next waypoint. This is a copy from the Unity 3D tutorial
 * 
 * */
using UnityEngine;
using System.Collections;

public class Waypoint : MonoBehaviour {

	//this is a Unity function which detects when an object enters this object's trigger collider
	void OnTriggerEnter(Collider hit){ // hit is the collider of the object which enters this trigger
		if(hit.CompareTag("character")){ //check the tag of the object to see if it is the enemy, if so...
			hit.GetComponent<AI>().NextWaypoint();// have the enemy move towards the next waypoint
		}
	}
}
