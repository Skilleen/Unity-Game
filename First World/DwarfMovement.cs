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
	public bool wolfCollide = false;
	public bool signContact = false;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();


	}
	// Update is called once per frame
	void FixedUpdate () {
		GameObject Goblin = GameObject.Find("Goblin");
		GoblinScript goblinScript = Goblin.GetComponent<GoblinScript>();

		GameObject Goblin1 = GameObject.Find("Goblin 1");
		GoblinScript goblinScript1 = Goblin1.GetComponent<GoblinScript>();

		GameObject WolfRider = GameObject.Find("WolfRider");
		WolfScript wolfScript = WolfRider.GetComponent<WolfScript>();

		GameObject Axe = GameObject.Find("Axe");
		AxScript axScript = Axe.GetComponent<AxScript>();
		
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
				if(goblinCollide && !goblinScript.goblinDead){
					goblinScript.goblinLife=goblinScript.goblinLife-3f; //Do Damage
					}
				else if(goblinCollide1 && !goblinScript.goblinDead){
					goblinScript1.goblinLife=goblinScript1.goblinLife-3f;
				}
				else if(wolfCollide){

					wolfScript.wolfLife=wolfScript.wolfLife-3f;
				}
			}
		}
		//Checking if the dwarf has been hit.
		if(goblinScript.playerHit && goblinScript.doDamage){
			anim.SetBool("hit", true);
			print(dwarfLife);
			dwarfLife=dwarfLife-0.1f;
	}
		if(goblinScript1.playerHit && goblinScript1.doDamage){
			anim.SetBool("hit", true);
			print(dwarfLife);
			dwarfLife=dwarfLife-0.1f;
		}
		if(wolfScript.playerHit && wolfScript.doDamage){
			anim.SetBool("hit", true);
			print(dwarfLife);
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
		if(col.gameObject.name == "Goblin"){
			goblinCollide = true;
		}
		if(col.gameObject.name == "Goblin 1"){
			goblinCollide1=true;
		}
		if(col.gameObject.name == "WolfRider"){
			wolfCollide=true;
		}
		if(col.gameObject.name == "Sign"){
		    signContact = true;
			GameObject sign = GameObject.Find("Canvas");
			Score score = sign.GetComponent<Score>();
			score.instruction.text="                                      Home of the Baba Clan";
		}
}
}