using UnityEngine;
using System.Collections;
/* Scott Killeen, March 5th, 2015
 * Methods for Dealing with the movements and animations of the Dwarf (Player)
 * 
 * */
public class DwarfMovement : MonoBehaviour {

	private Animator anim;
	public float speed = 3.5f;
	private bool dead = false;
	private bool facingRight = true; //Used for walking right and left animations.
	public float dwarfLife = 100f;
	private bool[] goblinCollides;//arrays to handle collisions. 
	private bool[] wolfCollides;
	private bool[] ogreCollides;
	//I usually avoid the use of global variables, but unity encourages it for working with the unity interface.
	public bool signContact = false;
	public bool caveContact = false;
	public GameObject[] goblinArray; //Array of Goblin objects.
	public GoblinScript[] scriptsArray; //scripts for goblins.
	public GameObject[] wolfArray; //Array of wolves.
	public GameObject[] ogreArray; //Array of ogres.
	public WolfScript[] scriptsArrayW; //scripts of wolves
	public OgreScript[] scriptsArrayO; //scripts of ogres.


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		//filling the collision arrays.
		goblinCollides = new bool[15];
		for(int i = 0; i<15; i++){
			goblinCollides[i]=false;
		}
		wolfCollides = new bool[5];
		for(int i = 0; i<5; i++){
			wolfCollides[i]=false;
		}
		ogreCollides = new bool[6];
		for(int i =0; i<6; i++){
			ogreCollides[i]=false;
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		GameObject Scroll = GameObject.Find("Scroll");
		ScrollScript scrollScript = Scroll.GetComponent<ScrollScript>();
		PlayerPrefs.SetFloat("health",dwarfLife);
		GameObject Axe = GameObject.Find("Axe");
		AxScript axScript = Axe.GetComponent<AxScript>();
			
		anim.SetBool("attack", false);
		anim.SetBool("walk", false); //reset animations on every update
		anim.SetBool("hit", false);

		//Reseting Color if Hit
		if(!scrollScript.hasScroll){
		for(int i = 0; i<15; i++){
			goblinArray[i].GetComponent<SpriteRenderer>().color = Color.white;
		}
		for(int i = 0; i<5; i++){
			wolfArray[i].GetComponent<SpriteRenderer>().color = Color.white;
		}
		for(int i =0; i<6; i++){
			ogreArray[i].GetComponent<SpriteRenderer>().color = Color.white;
		}
		}

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
				if(!scrollScript.hasScroll){
				//Here I handle the health and damage of each Goblin.
				 //Checks that they do not have the scroll yet
				for(int i=0; i<15;i++){
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
				for(int i=0; i<5;i++){
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
				for(int i=0; i<6;i++){
					if(ogreCollides[i] && !scriptsArrayO[i].ogreDead && !(facingRight==scriptsArrayO[i].facingRight) && scriptsArrayO[i].doDamage){
							ogreArray[i].GetComponent<SpriteRenderer>().color = Color.red;
							if(axScript.hasAxe){
							scriptsArrayO[i].ogreLife=scriptsArrayO[i].ogreLife-4f;
						}
						else{
							scriptsArrayO[i].ogreLife=scriptsArrayO[i].ogreLife-3f; //Do Damage
						}
					}
				}		
			}}
		}

		//Checking if the dwarf has been hit.
		if(!scrollScript.hasScroll){ //Checks that they do not have the scroll yet
		for(int i =0; i<15; i++){
			if(scriptsArray[i].playerHit && scriptsArray[i].doDamage){
				anim.SetBool("hit", true);
				dwarfLife=dwarfLife-0.1f;
			}
		}


		for(int i =0; i<5; i++){
			if(scriptsArrayW[i].playerHit && scriptsArrayW[i].doDamage){
				anim.SetBool("hit", true);
				dwarfLife=dwarfLife-0.1f;
			}
		}

		for(int i =0; i<6; i++){
			if(scriptsArrayO[i].playerHit && scriptsArrayO[i].doDamage){
				anim.SetBool("hit", true);
				dwarfLife=dwarfLife-0.1f;
			}
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
	}

	//Handiling Collisions.
	void OnCollisionEnter2D(Collision2D col){
		GameObject Scroll = GameObject.Find("Scroll");
		ScrollScript scrollScript = Scroll.GetComponent<ScrollScript>();
		GameObject sign = GameObject.Find("Canvas");
		Score score = sign.GetComponent<Score>();
		if(!scrollScript.hasScroll){

		//Dealing with collisions with the Goblins.
		for(int i = 0; i<15; i++){
			if(col.gameObject==goblinArray[i]){
				goblinCollides[i] = true;
			}
		}
		//Dealing with collisions with the Wolves.
		for(int i = 0; i<5; i++){
			if(col.gameObject==wolfArray[i]){
				wolfCollides[i] = true;
			}
		}
		//Dealing with collisions with the Ogres.
		for(int i = 0; i<6; i++){
			if(col.gameObject==ogreArray[i]){
				ogreCollides[i] = true;
			}
		}

		//For the Clan Sign.
		if(col.gameObject.name == "Sign"){
		    signContact = true;
			score.instruction.text="                  Home of the Baba Clan";
		}

		//For entering the cave (new scene.)
		if(col.gameObject.name == "CaveEntrance"){
			caveContact = true;
			GameObject Peasant = GameObject.Find("Peasant");
			NPC_Dialog npc = Peasant.GetComponent<NPC_Dialog>();
			if(npc.questAccept){
				score.instruction.text="  The Door unlocks! Press ENTER to proceed.";
			}
			else{
			score.instruction.text="                     The Door is Locked.";
			}
		}
		}

}
	void OnCollisionStay2D(Collision2D col){
		GameObject Scroll = GameObject.Find("Scroll");
		ScrollScript scrollScript = Scroll.GetComponent<ScrollScript>();
		if(col.gameObject.name == "CaveEntrance" && !scrollScript.hasScroll){
			GameObject Peasant = GameObject.Find("Peasant");
			NPC_Dialog npc = Peasant.GetComponent<NPC_Dialog>();
			if(npc.questAccept){
				if(Input.GetKey(KeyCode.Return)){
					Application.LoadLevel("World One Cave");
				}
			}
		}
	}
}