﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaterQuest : MonoBehaviour {

	public int eps = 20;
	//public GameObject finalBucket;
	public InventoryItem bucketInventoryItem;
	//private GUIText messageText;	//GUIElement
	private Text messageText;	//uGUI
	private string questMessage = "Du hast Durst.Suche einen Behälter, " +
		"um dieses Wasser zu trinken.";
	private string questMessage2 = "Du brauchst einen leeren Behälter.";
	private bool gotQuest = false;
	private string questEndedMessage = "<size=20>Gratulation!</size>\n" + 
		"Du hast deinen Durst gestillt. Jetzt finde den Parasiten!";
	private GameObject player;
	private Inventory inventory;
	private PlayerController playerController;
	private EPController epController;
	private bool questEnd;

	void Start () {
		//finalBucket.SetActive(false);
		questEnd = false;
		player = GameObject.FindGameObjectWithTag ("Player");
		playerController = player.GetComponent<PlayerController>();
		inventory = player.GetComponent<Inventory>();
		//messageText = GameObject.FindGameObjectWithTag ("Message").
		//	GetComponent<GUIText>();	//GUIElement
		messageText = GameObject.FindGameObjectWithTag ("Message").
			GetComponent<Text>();	//uGUI
		epController = GameObject.FindGameObjectWithTag("GameController").
			GetComponent<EPController>();

	}
	
	void OnTriggerEnter(Collider other) 
	{	
		if(other.gameObject == player && !questEnd)
		{
			if(inventory.RemoveItem(bucketInventoryItem))
			{
				questEnd = true;
				//finalBucket.SetActive(true);
				//Runterfallenden Bucket erzeugen
				//Quaternion rot = new Quaternion();
				//Drehung des urspruenglichen Modells ausgleichen
				//rot.eulerAngles = new Vector3(-90,0,0);
				Instantiate(bucketInventoryItem.prefab,player.transform.position + player.transform.forward + player.transform.up,Quaternion.identity);

				messageText.text = questEndedMessage;
				epController.AddPoints (eps);
			}
			else
			{
				if(gotQuest)
					messageText.text = questMessage2;
				else
					messageText.text = questMessage;
				gotQuest = true;
			}
		}
	}
	
	void OnTriggerExit(Collider other) 
	{	
		if(other.gameObject == player)
		{
			messageText.text = "";
		}
	}
}

