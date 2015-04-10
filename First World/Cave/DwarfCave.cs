using UnityEngine;
using System.Collections;
/* Scott Killeen, March 24th, 2015
 * Methods for Dealing with the movements and animations of the Dwarf (Player)
 * 
 * */
public class DwarfCave : MonoBehaviour {
	
	private Animator anim;
	public float speed = 3.5f;
	private bool dead = false;
	private bool facingRight = true; //Used for walking right and left animations.
	public float dwarfLife = 100f;
	private bool[] goblinCollides;//arrays to handle collisions. 
	private bool[] wolfCollides;
	private bool[] cyclopsCollides;
	private bool behemothCollide = false;
	//I usually avoid the use of global variables, but unity encourages it for working with the unity interface.
	public bool caveContact = false;
	public GameObject[] goblinArray; //Array of Goblin objects.
	public GameObject[] wolfArray; //Array of wolves.
	public GameObject[] cyclopsArray; //Array of ogres.
	public GoblinScript[] scriptsArray; //scripts for goblins.
	public WolfScript[] scriptsArrayW; //scripts of wolves
	public CyclopsScript[] scriptsArrayC; //scripts of ogres.

	
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		//filling the collision arrays.
		goblinCollides = new bool[13];
		for(int i = 0; i<13; i++){
			goblinCollides[i]=false;
		}
		wolfCollides = new bool[7];
		for(int i = 0; i<7; i++){
			wolfCollides[i]=false;
		}
		cyclopsCollides = new bool[3];
		for(int i =0; i<3; i++){
			cyclopsCollides[i]=false;
		}

		dwarfLife = PlayerPrefs.GetFloat("health");
		
		
	}
	// Update is called once per frame
	void FixedUpdate () {
		//for Boss
		GameObject Behemoth = GameObject.Find("Behemoth");
		BehemothScript behemothScript = Behemoth.GetComponent<BehemothScript>();

		GameObject Axe = GameObject.Find("Axe");
		AxScript axScript = Axe.GetComponent<AxScript>();

		anim.SetBool("attack", false);
		anim.SetBool("walk", false); //reset animations on every update
		anim.SetBool("hit", false);

		//Reseting Color if Hit
		for(int i = 0; i<13; i++){
			goblinArray[i].GetComponent<SpriteRenderer>().color = Color.white;
		}
		for(int i = 0; i<7; i++){
			wolfArray[i].GetComponent<SpriteRenderer>().color = Color.white;
		}

		for(int i =0; i<3; i++){
			cyclopsArray[i].GetComponent<SpriteRenderer>().color = Color.white;
		}

		Behemoth.GetComponent<SpriteRenderer>().color = Color.white;
		
		//Following Code is to get the player to move
		if (Input.GetKey(KeyCode.A) && !dead)
		{
			if(facingRight){
				Vector3 theScale = transform.localScale;
				theScale.x *= -1;
				transform.localScale = theScale;
				facingRight=false;
			}
			transform.position += Vector3.left * speed * Time.deltaTime;
			anim.SetBool("walk", true);
			anim.SetBool("attack", false);
		}
		if (Input.GetKey(KeyCode.D) && !dead)
		{
			if(!facingRight){
				Vector3 theScale = transform.localScale;
				theScale.x *= -1;
				transform.localScale = theScale;
				facingRight=true;
			}
			transform.position += Vector3.right * speed * Time.deltaTime;
			anim.SetBool("attack", false);
			anim.SetBool("walk", true);
		}
		if (Input.GetKey(KeyCode.W) && !dead)
		{
			transform.position += Vector3.up * speed * Time.deltaTime;
			anim.SetBool("attack", false);
			anim.SetBool("walk", true);
		}
		if (Input.GetKey(KeyCode.S) && !dead)
		{
			transform.position += Vector3.down * speed * Time.deltaTime;
			anim.SetBool("attack", false);
			anim.SetBool("walk", true);
			
		}
		//For attacking

		if(Input.GetMouseButton(0)) 
		{ 
			
			if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("Dwarf_attack"))
			{
				// Avoid any reload.
			}
			else{
				anim.SetBool("attack", true);
				//Here I handle the health and damage of each Goblin.
				for(int i=0; i<13;i++){
					if(goblinCollides[i] && !scriptsArray[i].goblinDead && !(facingRight==scriptsArray[i].facingRight) && scriptsArray[i].doDamage){
						goblinArray[i].GetComponent<SpriteRenderer>().color = Color.red;
						if(axScript.hasAxe){
							scriptsArray[i].goblinLife=scriptsArray[i].goblinLife-4f;
						}
						else{
							scriptsArray[i].goblinLife=scriptsArray[i].goblinLife-3f; //Do Damage
						}
					}
				}
				//Here I handle the health and damage of each Wolf.
				for(int i=0; i<7;i++){
					if(wolfCollides[i] && !scriptsArrayW[i].wolfDead && !(facingRight==scriptsArrayW[i].facingRight) && scriptsArrayW[i].doDamage){
						wolfArray[i].GetComponent<SpriteRenderer>().color = Color.red;
						if(axScript.hasAxe){
							scriptsArrayW[i].wolfLife=scriptsArrayW[i].wolfLife-4f;
						}
						else{
							scriptsArrayW[i].wolfLife=scriptsArrayW[i].wolfLife-3f; //Do Damage
						}
					}
				}
				//Here I handle the health and damage of each Ogre.
				for(int i=0; i<3;i++){
					if(cyclopsCollides[i] && !scriptsArrayC[i].cyclopsDead && !(facingRight==scriptsArrayC[i].facingRight) && scriptsArrayC[i].doDamage){
						cyclopsArray[i].GetComponent<SpriteRenderer>().color = Color.red;
						if(axScript.hasAxe){
							scriptsArrayC[i].cyclopsLife=scriptsArrayC[i].cyclopsLife-4f;
						}
						else{
							scriptsArrayC[i].cyclopsLife=scriptsArrayC[i].cyclopsLife-3f; //Do Damage
						}
					}
				}
				if(behemothCollide && !behemothScript.behemothDead && !(facingRight==behemothScript.facingRight) && behemothScript.doDamage){
					Behemoth.GetComponent<SpriteRenderer>().color = Color.red;
					if(axScript.hasAxe){
						behemothScript.behemothLife=behemothScript.behemothLife-4f;
					}
					else{
						behemothScript.behemothLife=behemothScript.behemothLife-3f; //Do Damage
					}
				}
			}}


		//Checking if the dwarf has been hit.
		for(int i =0; i<13; i++){
			if(scriptsArray[i].playerHit && scriptsArray[i].doDamage){
				anim.SetBool("hit", true);
				dwarfLife=dwarfLife-0.1f;
			}
		}
		
		
		for(int i =0; i<7; i++){
			if(scriptsArrayW[i].playerHit && scriptsArrayW[i].doDamage){
				anim.SetBool("hit", true);
				dwarfLife=dwarfLife-0.1f;
			}
		}
		
		for(int i =0; i<3; i++){
			if(scriptsArrayC[i].playerHit && scriptsArrayC[i].doDamage){
				anim.SetBool("hit", true);
				dwarfLife=dwarfLife-0.15f;
			}
		}
		if(behemothScript.playerHit && behemothScript.doDamage){
			anim.SetBool("hit",true);
			dwarfLife=dwarfLife-0.15f;
		}

		//For Death
		if(dwarfLife<=0){
			anim.SetBool("dead",true);
			anim.SetBool("attack", false);
			anim.SetBool("walk", false);
			anim.SetBool("hit", false);
			dead=true;
		}
	}
	
	
	//Handiling Collisions.
	void OnCollisionEnter2D(Collision2D col){
		GameObject sign = GameObject.Find("Canvas");
		ScoreCave score = sign.GetComponent<ScoreCave>();
		GameObject Scroll = GameObject.Find("Scroll");
		ScrollScript scrollScript = Scroll.GetComponent<ScrollScript>();
		
		//Dealing with collisions with the Goblins.

		for(int i = 0; i<13; i++){
			if(col.gameObject==goblinArray[i]){
				goblinCollides[i] = true;
			}
		}

		//Dealing with collisions with the Wolves.
		for(int i = 0; i<7; i++){
			if(col.gameObject==wolfArray[i]){
				wolfCollides[i] = true;
			}
		}
		//Dealing with collisions with the Ogres.
		for(int i = 0; i<3; i++){
			if(col.gameObject==cyclopsArray[i]){
				cyclopsCollides[i] = true;
			}
		}
		if(col.gameObject.name=="Behemoth"){
			behemothCollide = true;
		}

		if(col.gameObject.name=="Cave Exit" && !scrollScript.hasScroll){
			caveContact = true;
			score.instruction.text="             You still have work to do here.";
		}
		else if(col.gameObject.name=="Cave Exit" && scrollScript.hasScroll){
			score.instruction.text="                          \"Enter\" to Exit";
			caveContact = true;
		}

		
	}
	void OnCollisionStay2D(Collision2D col){
		GameObject Scroll = GameObject.Find("Scroll");
		ScrollScript scrollScript = Scroll.GetComponent<ScrollScript>();
		if(col.gameObject.name == "Cave Exit" && scrollScript.hasScroll){
			if(Input.GetKey(KeyCode.Return)){
				Application.LoadLevel("World One Done");
			}
		}
	}


}