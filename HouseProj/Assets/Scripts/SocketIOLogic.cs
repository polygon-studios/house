using UnityEngine;
using UnityEngine.SceneManagement;
using SocketIO;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


public class SocketIOLogic : MonoBehaviour
{
	private SocketIOComponent socket;
	public GameObject callingCharAnims;
	public GameObject laurels;
	public houseExt houseE;
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
		socket.On("redButton", redButton);
		socket.On ("endGame", endGame);
		socket.On ("resetHouse", resetHouse);
		laurels.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
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
			
			callingCharAnims.GetComponent<CallingCharAnimations> ().callAnimationWithItem (character, side, holdingItem);
			
			
			if (tempItem.Contains ("bramble")) {
				
			}

		}

	}

	public void redButton(SocketIOEvent e)
	{
		houseE.showJailBars ();
	}

	public void endGame (SocketIOEvent e){
		
		string first = string.Format ("{0}", e.data ["first"]);
		string second = string.Format ("{0}", e.data ["second"]);
		string third = string.Format ("{0}", e.data ["third"]);
		string fourth = string.Format ("{0}", e.data ["fourth"]);

        houseE.endGame = true;
		callingCharAnims.GetComponent<CallingCharAnimations> ().sleepingAnimations (first, second, third, fourth);
		laurels.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);

	}

	public void resetHouse (SocketIOEvent e){
		SceneManager.LoadScene (0);
	}

	public void resetGame (){
		
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
