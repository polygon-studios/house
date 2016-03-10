using UnityEngine;
using System.Collections;

public class houseExt : MonoBehaviour {

	SpriteRenderer renderer;

	// Use this for initialization
	void Start () {
		renderer = gameObject.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.K)){
			renderer.color = new Color(1f, 1f, 1f, 0f);
		}
		if(Input.GetKey(KeyCode.L)){
			renderer.color = new Color(1f, 1f, 1f, 1f);
		}
	}
	public void changeToInt(){
		renderer.color = new Color(1f, 1f, 1f, 0f);
	}

	public void changeToExt(){
		renderer.color = new Color(1f, 1f, 1f, 1f);
	}
}
