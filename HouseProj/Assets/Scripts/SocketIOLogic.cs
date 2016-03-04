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
		socket.On("playerEnter", fuckYou);
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
		/*Debug.Log("Character " + e.data["character"] + " came from " + e.data["side"] + " with ze item " + e.data["holdingItem"]);
		
		
		string tempSide = string.Format ("{0}", e.data ["side"]);
		float side = (float.Parse (tempSide)) * 1.0f;
		
		string tempChar = string.Format ("{0}", e.data ["character"]);
		string tempItem = string.Format ("{0}", e.data ["holdingItem"]);
		
		Debug.Log("Character " + tempChar + " came from " + side + " with ze item " + tempItem); */

		//Debug.Log(e.data["character"] + "Fox entering from:" + e.data["side"] + " holding an item: " + e.data["holdingItem"]);
		//fox, skunk, bear, rabbit
		//side: 2 is left, 1 is right
		//bool holding item

		/*string character = string.Format ("{0}", e.data ["character"]);


		string tempSide = string.Format ("{0}", e.data ["side"]);

		Debug.Log (tempSide);
		float side = float.Parse (tempSide);

		Debug.Log ("4");

		string holdingItem = string.Format ("{0}",e.data ["holdingItem"]);

		Debug.Log ("5");*/

		/*if (holdingItem.Contains ("none")) {

			Debug.Log ("char: " + character + "  tempSide: " + side + "  holdingItem :" + holdingItem);

			string tempItem = string.Format ("{0}", e.data ["item"]);

			callingCharAnims.GetComponent<CallingCharAnimations> ().callAnimationWithItem (character, side, holdingItem, tempItem);


			if (tempItem.Contains ("bramble")) {

			}
		} else {
			Debug.Log ("NOITEMCALLchar: " + character + "  tempSide: " + side);
			callingCharAnims.GetComponent<CallingCharAnimations> ().callAnimation (character, side);

		}*/

	}

	public void fuckYou (SocketIOEvent e){
		//Debug.Log("Character " + e.data["character"] + " came from " + e.data["side"] + " with ze item " + e.data["holdingItem"]);
		
		
		string tempSide = string.Format ("{0}", e.data ["side"]);
		int side = int.Parse (tempSide);
		
		string tempChar = string.Format ("{0}", e.data ["character"]);
		string tempItem = string.Format ("{0}", e.data ["holdingItem"]);
		
		Debug.Log("Character " + tempChar + " came from " + tempSide + " with ze item " + tempItem);
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
