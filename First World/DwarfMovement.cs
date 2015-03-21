using UnityEngine;
using System.Collections;
/* Scott Killeen, March 5th, 2015
 * Methods for Dealing with the movements and animations of the Dwarf (Player)
 * 
 * */
public class DwarfMovement : MonoBehaviour {

	Animator anim;
	public float speed = 3.5f;
	public bool dead = false;
	public bool facingRight = true;
	public float dwarfLife = 100f;
	public bool goblinCollide = false;
	public bool goblinCollide1 = false;
	public bool goblinCollide2 = false;
	public bool goblinCollide3 = false;
	public bool goblinCollide4 = false;
	public bool goblinCollide5 = false;
	public bool goblinCollide6 = false;
	public bool goblinCollide7 = false;
	public bool goblinCollide8 = false;
	public bool goblinCollide9 = false;
	public bool goblinCollide10 = false;
	public bool goblinCollide11 = false;
	public bool goblinCollide12 = false;
	public bool goblinCollide13 = false;
	public bool goblinCollide14 = false;
	public bool wolfCollide = false;
	public bool wolfCollide1 = false;
	public bool wolfCollide2 = false;
	public bool wolfCollide3 = false;
	public bool wolfCollide4 = false;
	public bool ogreCollide = false;
	public bool ogreCollide1 = false;
	public bool ogreCollide2 = false;
	public bool ogreCollide3 = false;
	public bool ogreCollide4 = false;
	public bool ogreCollide5 = false;
	public bool signContact = false;
	public bool caveContact = false;
	public GameObject[] goblinArray;



	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();


	}
	// Update is called once per frame
	void FixedUpdate () {
		goblinArray = new GameObject[15];
		for(int i = 0; i < 15; i++){
			GameObject Goblin = GameObject.Find("Goblin "+i);
			goblinArray[i] = Goblin;
		}

		GameObject firstGoblin = GameObject.Find("Goblin");
		GoblinScript goblinScript = firstGoblin.GetComponent<GoblinScript>();

		//Scripts for Each Goblin, used Array to make it look cleaner.
		GoblinScript goblinScript1 = goblinArray[1].GetComponent<GoblinScript>();
		GoblinScript goblinScript2 = goblinArray[2].GetComponent<GoblinScript>();
		GoblinScript goblinScript3 = goblinArray[3].GetComponent<GoblinScript>();
		GoblinScript goblinScript4 = goblinArray[4].GetComponent<GoblinScript>();
		GoblinScript goblinScript5 = goblinArray[5].GetComponent<GoblinScript>();
		GoblinScript goblinScript6 = goblinArray[6].GetComponent<GoblinScript>();
		GoblinScript goblinScript7 = goblinArray[7].GetComponent<GoblinScript>();
		GoblinScript goblinScript8 = goblinArray[8].GetComponent<GoblinScript>();
		GoblinScript goblinScript9 = goblinArray[9].GetComponent<GoblinScript>();
		GoblinScript goblinScript10 = goblinArray[10].GetComponent<GoblinScript>();
		GoblinScript goblinScript11 = goblinArray[11].GetComponent<GoblinScript>();
		GoblinScript goblinScript12 = goblinArray[12].GetComponent<GoblinScript>();
		GoblinScript goblinScript13 = goblinArray[13].GetComponent<GoblinScript>();
		GoblinScript goblinScript14 = goblinArray[14].GetComponent<GoblinScript>();



		GameObject WolfRider = GameObject.Find("WolfRider");
		WolfScript wolfScript = WolfRider.GetComponent<WolfScript>();
		GameObject WolfRider1 = GameObject.Find("WolfRider 1");
		WolfScript wolfScript1 = WolfRider1.GetComponent<WolfScript>();
		GameObject WolfRider2 = GameObject.Find("WolfRider 2");
		WolfScript wolfScript2 = WolfRider2.GetComponent<WolfScript>();
		GameObject WolfRider3 = GameObject.Find("WolfRider 3");
		WolfScript wolfScript3 = WolfRider3.GetComponent<WolfScript>();
		GameObject WolfRider4 = GameObject.Find("WolfRider 4");
		WolfScript wolfScript4 = WolfRider4.GetComponent<WolfScript>();

		GameObject Ogre = GameObject.Find("Ogre");
		OgreScript ogreScript = Ogre.GetComponent<OgreScript>();
		GameObject Ogre1 = GameObject.Find("Ogre 1");
		OgreScript ogreScript1 = Ogre1.GetComponent<OgreScript>();
		GameObject Ogre2 = GameObject.Find("Ogre 2");
		OgreScript ogreScript2 = Ogre2.GetComponent<OgreScript>();
		GameObject Ogre3 = GameObject.Find("Ogre 3");
		OgreScript ogreScript3 = Ogre3.GetComponent<OgreScript>();
		GameObject Ogre4 = GameObject.Find("Ogre 4");
		OgreScript ogreScript4 = Ogre4.GetComponent<OgreScript>();
		GameObject Ogre5 = GameObject.Find("Ogre 5");
		OgreScript ogreScript5 = Ogre5.GetComponent<OgreScript>();


		GameObject Axe = GameObject.Find("Axe");
		AxScript axScript = Axe.GetComponent<AxScript>();

		GameObject sign = GameObject.Find("Canvas");
		Score score = sign.GetComponent<Score>();
		
		anim.SetBool("attack", false);
		anim.SetBool("walk", false); //reset animations on every update
		anim.SetBool("hit", false);

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

				//Here I handle the health and damage of each Goblin. Its messy, I plan to find a better way.

				if(goblinCollide && !goblinScript.goblinDead && !(facingRight==goblinScript.facingRight)){
					if(axScript.hasAxe){
						goblinScript.goblinLife=goblinScript.goblinLife-4f;
					}
					else{
						goblinScript.goblinLife=goblinScript.goblinLife-3f; //Do Damage
					}
					}
				else if(goblinCollide1 && !goblinScript1.goblinDead && !(facingRight==goblinScript1.facingRight)){
					if(axScript.hasAxe){
						goblinScript1.goblinLife=goblinScript1.goblinLife-4f;
					}
					else{
					goblinScript1.goblinLife=goblinScript1.goblinLife-3f;
					}
				}
				else if(goblinCollide2 && !goblinScript2.goblinDead && !(facingRight==goblinScript2.facingRight)){
					if(axScript.hasAxe){
						goblinScript2.goblinLife=goblinScript2.goblinLife-4f;
					}
					else{
						goblinScript2.goblinLife=goblinScript2.goblinLife-3f;
					}
				}
				else if(goblinCollide3 && !goblinScript3.goblinDead && !(facingRight==goblinScript3.facingRight)){
					if(axScript.hasAxe){
						goblinScript3.goblinLife=goblinScript3.goblinLife-4f;
					}
					else{
						goblinScript3.goblinLife=goblinScript3.goblinLife-3f;
					}
				}
				else if(goblinCollide4 && !goblinScript4.goblinDead && !(facingRight==goblinScript4.facingRight)){
					if(axScript.hasAxe){
						goblinScript4.goblinLife=goblinScript4.goblinLife-4f;
					}
					else{
						goblinScript4.goblinLife=goblinScript4.goblinLife-3f;
					}
				}
				else if(goblinCollide5 && !goblinScript5.goblinDead && !(facingRight==goblinScript5.facingRight)){
					if(axScript.hasAxe){
						goblinScript5.goblinLife=goblinScript5.goblinLife-4f;
					}
					else{
						goblinScript5.goblinLife=goblinScript5.goblinLife-3f;
					}
				}
				else if(goblinCollide6 && !goblinScript6.goblinDead && !(facingRight==goblinScript6.facingRight)){
					if(axScript.hasAxe){
						goblinScript6.goblinLife=goblinScript6.goblinLife-4f;
					}
					else{
						goblinScript6.goblinLife=goblinScript6.goblinLife-3f;
					}
				}
				else if(goblinCollide7 && !goblinScript7.goblinDead && !(facingRight==goblinScript7.facingRight)){
					if(axScript.hasAxe){
						goblinScript7.goblinLife=goblinScript7.goblinLife-4f;
					}
					else{
						goblinScript7.goblinLife=goblinScript7.goblinLife-3f;
					}
				}
				else if(goblinCollide8 && !goblinScript8.goblinDead && !(facingRight==goblinScript8.facingRight)){
					if(axScript.hasAxe){
						goblinScript8.goblinLife=goblinScript8.goblinLife-4f;
					}
					else{
						goblinScript8.goblinLife=goblinScript8.goblinLife-3f;
					}
				}
				else if(goblinCollide9 && !goblinScript9.goblinDead && !(facingRight==goblinScript9.facingRight)){
					if(axScript.hasAxe){
						goblinScript9.goblinLife=goblinScript9.goblinLife-4f;
					}
					else{
						goblinScript9.goblinLife=goblinScript9.goblinLife-3f;
					}
				}
				else if(goblinCollide10 && !goblinScript10.goblinDead && !(facingRight==goblinScript10.facingRight)){
					if(axScript.hasAxe){
						goblinScript10.goblinLife=goblinScript10.goblinLife-4f;
					}
					else{
						goblinScript10.goblinLife=goblinScript10.goblinLife-3f;
					}
				}
				else if(goblinCollide11 && !goblinScript11.goblinDead && !(facingRight==goblinScript11.facingRight)){
					if(axScript.hasAxe){
						goblinScript11.goblinLife=goblinScript11.goblinLife-4f;
					}
					else{
						goblinScript11.goblinLife=goblinScript11.goblinLife-3f;
					}
				}
				else if(goblinCollide12 && !goblinScript12.goblinDead && !(facingRight==goblinScript12.facingRight)){
					if(axScript.hasAxe){
						goblinScript12.goblinLife=goblinScript12.goblinLife-4f;
					}
					else{
						goblinScript12.goblinLife=goblinScript12.goblinLife-3f;
					}
				}
				else if(goblinCollide13 && !goblinScript13.goblinDead && !(facingRight==goblinScript13.facingRight)){
					if(axScript.hasAxe){
						goblinScript13.goblinLife=goblinScript13.goblinLife-4f;
					}
					else{
						goblinScript13.goblinLife=goblinScript13.goblinLife-3f;
					}
				}
				else if(goblinCollide14 && !goblinScript14.goblinDead && !(facingRight==goblinScript14.facingRight)){
					if(axScript.hasAxe){
						goblinScript14.goblinLife=goblinScript14.goblinLife-4f;
					}
					else{
						goblinScript14.goblinLife=goblinScript14.goblinLife-3f;
					}
				}


				//For wolf Damage
				else if(wolfCollide && !wolfScript.wolfDead && !(facingRight==wolfScript.facingRight)){
					if(axScript.hasAxe){
						wolfScript.wolfLife=wolfScript.wolfLife-4f;
					}
					else{
					wolfScript.wolfLife=wolfScript.wolfLife-3f;
					}
				}
				else if(wolfCollide1 && !wolfScript1.wolfDead && !(facingRight==wolfScript1.facingRight)){
					if(axScript.hasAxe){
						wolfScript1.wolfLife=wolfScript1.wolfLife-4f;
					}
					else{
						wolfScript1.wolfLife=wolfScript1.wolfLife-3f;
					}
				}
				else if(wolfCollide2 && !wolfScript2.wolfDead && !(facingRight==wolfScript2.facingRight)){
					if(axScript.hasAxe){
						wolfScript2.wolfLife=wolfScript2.wolfLife-4f;
					}
					else{
						wolfScript2.wolfLife=wolfScript2.wolfLife-3f;
					}
				}
				else if(wolfCollide3 && !wolfScript3.wolfDead && !(facingRight==wolfScript3.facingRight)){
					if(axScript.hasAxe){
						wolfScript3.wolfLife=wolfScript3.wolfLife-4f;
					}
					else{
						wolfScript3.wolfLife=wolfScript3.wolfLife-3f;
					}
				}
				else if(wolfCollide4 && !wolfScript4.wolfDead && !(facingRight==wolfScript4.facingRight)){
					if(axScript.hasAxe){
						wolfScript4.wolfLife=wolfScript4.wolfLife-4f;
					}
					else{
						wolfScript4.wolfLife=wolfScript4.wolfLife-3f;
					}
				}


				//for Ogre Damage
				else if(ogreCollide && !ogreScript.ogreDead && !(facingRight==ogreScript.facingRight)){
					if(axScript.hasAxe)
						ogreScript.ogreLife=ogreScript.ogreLife-4f;
					else
						ogreScript.ogreLife=ogreScript.ogreLife-3f;
				}
				else if(ogreCollide1 && !ogreScript1.ogreDead && !(facingRight==ogreScript1.facingRight)){
					if(axScript.hasAxe)
						ogreScript1.ogreLife=ogreScript1.ogreLife-4f;
					else
						ogreScript1.ogreLife=ogreScript1.ogreLife-3f;
				}
				else if(ogreCollide2 && !ogreScript2.ogreDead && !(facingRight==ogreScript2.facingRight)){
					if(axScript.hasAxe)
						ogreScript2.ogreLife=ogreScript2.ogreLife-4f;
					else
						ogreScript2.ogreLife=ogreScript2.ogreLife-3f;
				}
				else if(ogreCollide3 && !ogreScript3.ogreDead && !(facingRight==ogreScript3.facingRight)){
					if(axScript.hasAxe)
						ogreScript3.ogreLife=ogreScript3.ogreLife-4f;
					else
						ogreScript3.ogreLife=ogreScript3.ogreLife-3f;
				}
				else if(ogreCollide4 && !ogreScript4.ogreDead && !(facingRight==ogreScript4.facingRight)){
					if(axScript.hasAxe)
						ogreScript4.ogreLife=ogreScript4.ogreLife-4f;
					else
						ogreScript4.ogreLife=ogreScript4.ogreLife-3f;
				}
				else if(ogreCollide5 && !ogreScript5.ogreDead && !(facingRight==ogreScript5.facingRight)){
					if(axScript.hasAxe)
						ogreScript5.ogreLife=ogreScript5.ogreLife-4f;
					else
						ogreScript5.ogreLife=ogreScript5.ogreLife-3f;
				}
			}
		}


		//Checking if the dwarf has been hit.
		if(goblinScript.playerHit && goblinScript.doDamage){
			anim.SetBool("hit", true);
			dwarfLife=dwarfLife-0.1f;
	}
		if(goblinScript1.playerHit && goblinScript1.doDamage){
			anim.SetBool("hit", true);
			dwarfLife=dwarfLife-0.1f;
		}
		if(goblinScript2.playerHit && goblinScript2.doDamage){
			anim.SetBool("hit", true);
			dwarfLife=dwarfLife-0.1f;
		}
		if(goblinScript3.playerHit && goblinScript3.doDamage){
			anim.SetBool("hit", true);
			dwarfLife=dwarfLife-0.1f;
		}
		if(goblinScript4.playerHit && goblinScript4.doDamage){
			anim.SetBool("hit", true);
			dwarfLife=dwarfLife-0.1f;
		}
		if(goblinScript5.playerHit && goblinScript5.doDamage){
			anim.SetBool("hit", true);
			dwarfLife=dwarfLife-0.1f;
		}
		if(goblinScript6.playerHit && goblinScript6.doDamage){
			anim.SetBool("hit", true);
			dwarfLife=dwarfLife-0.1f;
		}
		if(goblinScript7.playerHit && goblinScript7.doDamage){
			anim.SetBool("hit", true);
			dwarfLife=dwarfLife-0.1f;
		}
		if(goblinScript8.playerHit && goblinScript8.doDamage){
			anim.SetBool("hit", true);
			dwarfLife=dwarfLife-0.1f;
		}
		if(goblinScript9.playerHit && goblinScript9.doDamage){
			anim.SetBool("hit", true);
			dwarfLife=dwarfLife-0.1f;
		}
		if(goblinScript10.playerHit && goblinScript10.doDamage){
			anim.SetBool("hit", true);
			dwarfLife=dwarfLife-0.1f;
		}
		if(goblinScript11.playerHit && goblinScript11.doDamage){
			anim.SetBool("hit", true);
			dwarfLife=dwarfLife-0.1f;
		}
		if(goblinScript12.playerHit && goblinScript12.doDamage){
			anim.SetBool("hit", true);
			dwarfLife=dwarfLife-0.1f;
		}
		if(goblinScript13.playerHit && goblinScript13.doDamage){
			anim.SetBool("hit", true);
			dwarfLife=dwarfLife-0.1f;
		}
		if(goblinScript14.playerHit && goblinScript14.doDamage){
			anim.SetBool("hit", true);
			dwarfLife=dwarfLife-0.1f;
		}



		if(wolfScript.playerHit && wolfScript.doDamage){
			anim.SetBool("hit", true);
			dwarfLife=dwarfLife-0.1f;
		}
		if(wolfScript1.playerHit && wolfScript1.doDamage){
			anim.SetBool("hit", true);
			dwarfLife=dwarfLife-0.1f;
		}
		if(wolfScript2.playerHit && wolfScript2.doDamage){
			anim.SetBool("hit", true);
			dwarfLife=dwarfLife-0.1f;
		}
		if(wolfScript3.playerHit && wolfScript3.doDamage){
			anim.SetBool("hit", true);
			dwarfLife=dwarfLife-0.1f;
		}
		if(wolfScript4.playerHit && wolfScript4.doDamage){
			anim.SetBool("hit", true);
			dwarfLife=dwarfLife-0.1f;
		}


		if(ogreScript.playerHit && ogreScript.doDamage){
			anim.SetBool("hit", true);
			dwarfLife=dwarfLife-0.1f;
		}
		if(ogreScript1.playerHit && ogreScript1.doDamage){
			anim.SetBool("hit", true);
			dwarfLife=dwarfLife-0.1f;
		}
		if(ogreScript2.playerHit && ogreScript2.doDamage){
			anim.SetBool("hit", true);
			dwarfLife=dwarfLife-0.1f;
		}
		if(ogreScript3.playerHit && ogreScript3.doDamage){
			anim.SetBool("hit", true);
			dwarfLife=dwarfLife-0.1f;
		}
		if(ogreScript4.playerHit && ogreScript4.doDamage){
			anim.SetBool("hit", true);
			dwarfLife=dwarfLife-0.1f;
		}
		if(ogreScript5.playerHit && ogreScript5.doDamage){
			anim.SetBool("hit", true);
			dwarfLife=dwarfLife-0.1f;
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
		Score score = sign.GetComponent<Score>();
		//Dealing with collisions with the Goblins.
		if(col.gameObject.name == "Goblin"){
			goblinCollide = true;
		}
		if(col.gameObject.name == "Goblin 1"){
			goblinCollide1=true;
		}
		if(col.gameObject.name == "Goblin 2"){
			goblinCollide2=true;
		}
		if(col.gameObject.name == "Goblin 3"){
			goblinCollide3=true;
		}
		if(col.gameObject.name == "Goblin 4"){
			goblinCollide4=true;
		}
		if(col.gameObject.name == "Goblin 5"){
			goblinCollide5=true;
		}
		if(col.gameObject.name == "Goblin 6"){
			goblinCollide6=true;
		}
		if(col.gameObject.name == "Goblin 7"){
			goblinCollide7=true;
		}
		if(col.gameObject.name == "Goblin 8"){
			goblinCollide8=true;
		}
		if(col.gameObject.name == "Goblin 9"){
			goblinCollide9=true;
		}
		if(col.gameObject.name == "Goblin 10"){
			goblinCollide10=true;
		}
		if(col.gameObject.name == "Goblin 11"){
			goblinCollide11=true;
		}
		if(col.gameObject.name == "Goblin 12"){
			goblinCollide12=true;
		}
		if(col.gameObject.name == "Goblin 13"){
			goblinCollide13=true;
		}
		if(col.gameObject.name == "Goblin 14"){
			goblinCollide14=true;
		}

		//Dealing with the collisions with the Wolfs
		if(col.gameObject.name == "WolfRider"){
			wolfCollide=true;
		}
		if(col.gameObject.name == "WolfRider 1"){
			wolfCollide1=true;
		}
		if(col.gameObject.name == "WolfRider 2"){
			wolfCollide2=true;
		}
		if(col.gameObject.name == "WolfRider 3"){
			wolfCollide3=true;
		}
		if(col.gameObject.name == "WolfRider 4"){
			wolfCollide4=true;
		}

		//Dealing with Collisions with the Ogres
		if(col.gameObject.name=="Ogre"){
			ogreCollide = true;
		}
		if(col.gameObject.name=="Ogre 1"){
			ogreCollide1 = true;
		}
		if(col.gameObject.name=="Ogre 2"){
			ogreCollide2 = true;
		}
		if(col.gameObject.name=="Ogre 3"){
			ogreCollide3 = true;
		}
		if(col.gameObject.name=="Ogre 4"){
			ogreCollide4 = true;
		}
		if(col.gameObject.name=="Ogre 5"){
			ogreCollide5 = true;
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
				score.instruction.text="                                 The Door unlocks! Press ENTER to proceed..";
			}
			else{
			score.instruction.text="                         The Door is Locked.";
			}
		}

}
}