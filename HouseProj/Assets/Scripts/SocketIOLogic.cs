using UnityEngine;
using SocketIO;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


public class SocketIOLogic : MonoBehaviour
{
	private SocketIOComponent socket;
	
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
		Debug.Log(e.data["character"] + "Fox entering from:" + e.data["side"] + " holding an item: " + e.data["holdingItem"]);

		string character = string.Format ("{0}", e.data ["character"]);

		string tempSide = string.Format ("{0}", e.data ["side"]);
		float side = (float.Parse (tempSide));

		bool holdingItem = Convert.ToBoolean (e.data ["holdingItem"]);

		if (holdingItem) {
			string tempTrap = string.Format ("{0}", e.data ["item"]);

			if (tempTrap.Contains ("bramble")) {

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
