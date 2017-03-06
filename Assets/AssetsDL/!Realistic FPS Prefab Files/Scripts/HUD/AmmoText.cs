//AmmoText.cs by Azuline StudiosÂ© All Rights Reserved
using UnityEngine;
using System.Collections;

public class AmmoText : MonoBehaviour {
	//draw ammo amount on screen
	public int ammoGui = 0;
	public int ammoGui2 = 0;
	public Color textColor;
	public float horizontalOffset = 0.95f;
	public float verticalOffset = 0.075f;
	public float horizontalOffsetAmt = 0.78f;
	public float verticalOffsetAmt = 0.1f;
	
	void start (){
		horizontalOffsetAmt = horizontalOffset;
		verticalOffsetAmt = verticalOffset;	
	}
	
	void Update (){
		GetComponent<GUIText>().text = "Ammo : "+ ammoGui.ToString()+" / "+ ammoGui2.ToString();
		GetComponent<GUIText>().pixelOffset = new Vector2 (Screen.width * horizontalOffsetAmt, Screen.height * verticalOffsetAmt);
		GetComponent<GUIText>().material.color = textColor;
	
	}
}