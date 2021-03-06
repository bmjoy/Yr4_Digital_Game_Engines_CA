﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveTheGirl : MonoBehaviour {

	public Text yapyapyap;
//	public Text actionText;
	public GameObject gun;
	public Canvas playerHUD;													// Disable when fade to dead animation enabled
	public Animator fadeToBoom;													// Show message when game completed

	private string playerName;													// Players name
	private GameObject gc;														// Access game controller components
	private Text infoMsg;														// Replaces actionText, for displaying information messages

	// Use this for initialization
	void Start () {
		infoMsg = GameObject.FindWithTag ("InfoMessage").GetComponent<Text> ();	// Locate the information text object
		playerName = PlayerPrefs.GetString ("PlayerName");
		gc = GameObject.FindWithTag ("GameController");

		//GirlRescued ()name Test
	}

	public void GirlRescued(){
		StartCoroutine (StartJibberJabbering ());
	}


	// End of game dialogue
	IEnumerator StartJibberJabbering(){
		yapyapyap.text = "Who is it?";
		yield return new WaitForSeconds (2);

		yapyapyap.text = "Oh, it's you " + playerName;
		yield return new WaitForSeconds (2);

		yapyapyap.text = "I missed you so much\nLets get out of here";
		yield return new WaitForSeconds (2);

		yapyapyap.text = "I just need to grab my research";
		yield return new WaitForSeconds (2);

		yapyapyap.text = "";
		infoMsg.text = "Your research?\nYou did all this?";
		yield return new WaitForSeconds (2);

		infoMsg.text = "";
		yapyapyap.text = "Yes, it's my lifes work";
		yield return new WaitForSeconds (2);

		yapyapyap.text = "";
		infoMsg.text = "I'm sorry but\nThere's only one thing I can do now";
		yield return new WaitForSeconds (2);

		infoMsg.text = "You have to die!!!";
		yield return new WaitForSeconds (1);

		gun.GetComponent<GunFire> ().Reload ();
		yield return new WaitForSeconds (1);

		gc.GetComponent<ExitLevel> ().SaveState ();
		playerHUD.enabled = false;
		fadeToBoom.SetTrigger ("Fade");
	}
}
