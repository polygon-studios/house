using UnityEngine;
using SocketIO;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


public class SocketIOLogic : MonoBehaviour
{
	private SocketIOComponent socket;
	public GameObject callingCharAnims;
	int side;
	
	public void Start()
	{
		GameObject go = GameObject.FindWithTag("SocketIO");
		if (go) {
			socket = go.GetComponent<SocketIOComponent> ();
		}
		socket.On("open", SocketOpen);
		socket.On("news", TestBoop);
		socket.On("error", SocketError);
		socket.On("close", SocketClose);
		socket.On("playerEnter", playerEnter);
	}
	
	public void Update()
	{

	}
	

	public void TestBoop(SocketIOEvent e)
	{
		Debug.Log("[SocketIO] Boop received: " + e.name + " " + e.data);
		
		if (e.data == null) { return; }
		
		Debug.Log(
			"#####################################################" +
			"THIS: " + e.data.GetField("this").str +
			"#####################################################"
			);
	}


	public void playerEnter(SocketIOEvent e)
	{
		string side = string.Format ("{0}", e.data ["side"]);
		string character = string.Format ("{0}", e.data ["character"]);
		string holdingItem = string.Format ("{0}", e.data ["holdingItem"]);

		if (holdingItem.Contains ("none")) {

			Debug.Log ("NOITEMCALLchar: " + character + "  tempSide: " + side);
			callingCharAnims.GetComponent<CallingCharAnimations> ().callAnimation (character, side);


		} else {
			Debug.Log ("char: " + character + "  tempSide: " + side + "  holdingItem :" + holdingItem);
			
			string tempItem = "chili";
			
			callingCharAnims.GetComponent<CallingCharAnimations> ().callAnimationWithItem (character, side, holdingItem, tempItem);
			
			
			if (tempItem.Contains ("bramble")) {
				
			}

		}

	}


	
	/*
	 *
	 * Open, close and error handling functions
	 *
	 */
	
	public void SocketOpen(SocketIOEvent e)
	{
		Debug.Log("[SocketIO] Open received: " + e.name + " " + e.data);
	}
	
	public void SocketError(SocketIOEvent e)
	{
		Debug.Log("[SocketIO] Error received: " + e.name + " " + e.data);
	}
	
	public void SocketClose(SocketIOEvent e)
	{
		Debug.Log("[SocketIO] Close received: " + e.name + " " + e.data);
	}
}
