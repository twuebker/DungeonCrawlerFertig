using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealth : HealthController {
	private Text messageText;	
	public bool isShocked = false;
	public float shockedTime = 0.5F;
	public int eps = 1;
	public GameObject other;
	public bool iBims;
	private EnemySonar enemySonar;
	private EPController epController;
	private Animator anim;
	private int hitTrigger;
	private int dieBool;
	private AudioSource audioSource;
	void Start()
	{
		enemySonar = GetComponent<EnemySonar>();
		epController = GameObject.FindGameObjectWithTag("GameController").
			GetComponent<EPController>();
		hitTrigger = Animator.StringToHash ("Hit");
		dieBool = Animator.StringToHash ("Die");
		anim = transform.GetComponent<Animator>();
		audioSource = GetComponent<AudioSource>();
		messageText = GameObject.FindGameObjectWithTag ("Message").
			GetComponent<Text>();	//uGUI
	}

	public override void Damaging ()
	{	
		anim.SetTrigger(hitTrigger);
		audioSource.Play ();
		isShocked = true;

		if(!enemySonar.playerDetected)		
			enemySonar.StopSearching();

		Invoke("ResetShocked",shockedTime);
	}

	public override void Dying ()
	{
		anim.SetBool(dieBool,true);
		anim.SetTrigger(hitTrigger);
		audioSource.Play ();
		isShocked = true;
		if (iBims) {
			messageText.text = "Gratulation! Der Parasit ist erledigt, du hast es geschafft!";
		}
		Invoke ("DestroyMe",1);
	}

	void ResetShocked()
	{
		isShocked = false;
	}

	void DestroyMe()
	{
		Destroy(gameObject);
		epController.AddPoints (eps);
	}

}
