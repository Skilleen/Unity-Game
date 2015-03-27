using UnityEngine;
using System.Collections;
/* Scott Killeen, March 25th, 2015
 * Methods for Dealing with the movements and animations of the Cyclops (Enemy)
 * 
 * */
public class CyclopsScript : MonoBehaviour {
	//Variables for getting the goblin to follow the Player and to react to animations.
	public Transform target;
	public float speed = 3f;
	private float maxDistance = 30f;
	private float attackDistance = 5f;
	private float range;
	private Animator anim;
	//I usually avoid the use of global variables, but unity encourages it for working with the unity interface.
	public bool cyclopsDead=false;
	public bool doDamage=false; //if both below are true.
	public bool playerHit=false; //If the cyclops hits the player
	public bool inRange=false; //If player is in range
	public float cyclopsLife=200f; 
	public Rigidbody2D rb;
	public bool facingRight=true;
	
	
	void Start () { 
		anim = GetComponent<Animator>();
	}
	
	void FixedUpdate ()
	{	
		
		doDamage=false;
		playerHit=false;
		//To find and move to the Player
		float myposition = transform.position.x;
		float dwarfposition = target.position.x;
		if (dwarfposition >myposition && !facingRight){
			Flip(); }
		else if(myposition > dwarfposition && facingRight){
			Flip();
		}
		range = Vector2.Distance(transform.position, target.position);
		//If Player is in range, start moving towards.
		if (range < maxDistance)
		{
			anim.SetBool("walk",true);
			transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
		}
		else{
			anim.SetBool("walk",false);
		}
		if (range > attackDistance){
			anim.SetBool("attack",false);
		}
		if (range < 3f) {
			if(anim.GetBool("attack")==true){
				playerHit = true;
				doDamage=true;}
		}
		//Death
		if(cyclopsLife<=0){
			transform.position = new Vector3(transform.position.x,transform.position.y,2); //move on the z.
			anim.SetBool("dead",true);
			anim.SetBool("attack", false);
			anim.SetBool("walk", false);
			speed = 0f;
			cyclopsDead=true;
			rb.isKinematic = true;
			BoxCollider2D b; //Remove the collision box.
			b = GetComponent<BoxCollider2D>();
			b.enabled = false;
		}
	}
	//Handles Collisions
	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.name == "Dwarf" && !cyclopsDead){
			anim.SetBool("attack",true);
			if (range < attackDistance){
				playerHit = true;
			}
			
		}
		
	}
	//To face left and right
	void Flip ()
	{
		if(!cyclopsDead){
			facingRight = !facingRight;		
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
	}
	
	
}
