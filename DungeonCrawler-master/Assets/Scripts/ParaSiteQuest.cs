using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ParaSiteQuest : MonoBehaviour {

	public int eps = 20;
	//private GUIText messageText;	//GUIElement
	private Text messageText;	//uGUI
	private string questMessage = "Gut gemacht. Du hast das Tor geöffnet, " +
		"nun töte den Parasiten!";
	private string questMessage2 = "Töte den Parasiten!";
	private bool gotQuest = false;
	private string questEndedMessage = "<size=20>Gratulation!</size>\n" + 
		"Du hast den Parasiten getötet. Gratulation!";
	private GameObject player;
	private Inventory inventory;
	private EnemyHealth parasiteHealth;
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
			if(gotQuest)
				messageText.text = questMessage2;
			else
				messageText.text = questMessage;
			gotQuest = true;
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

