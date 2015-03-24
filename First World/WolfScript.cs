using UnityEngine;
using System.Collections;
/* Scott Killeen, March 5th, 2015
 * Methods for Dealing with the movements and animations of the Wolf Rider.
 * 
 * */
public class WolfScript : MonoBehaviour {

	public Transform target;
	public float speed = 3f;
	private float maxDistance = 30f;
	private float attackDistance = 5f;
	private float range;
	//I usually avoid the use of global variables, but unity encourages it for working with the unity interface.
	public bool wolfDead=false;
	public bool doDamage=false; //if both below are true.
	public bool playerHit=false; //If the wolf hits the player
	public bool inRange=false; //If player is in range
	public float wolfLife=100f;
	public bool facingRight=true;
	public Rigidbody2D rb;
	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
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
		if (range < 4f) {
			if(anim.GetBool("attack")==true){
				playerHit = true;
				doDamage=true;}
		}

		//Death
		if(wolfLife<=0){
			transform.position = new Vector3(transform.position.x,transform.position.y,2); //move on z.
			anim.SetBool("dead",true);
			anim.SetBool("attack", false);
			anim.SetBool("walk", false);
			speed = 0f;
			wolfDead=true;
			rb.isKinematic = true;
			BoxCollider2D b; //Remove collider.
			b = GetComponent<BoxCollider2D>();
			b.enabled = false;
		}
	}
	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.name == "Dwarf" && !wolfDead){
			anim.SetBool("attack",true);
			if (range < attackDistance){
				playerHit = true;
			}
			
		}
		
	}
	//To face left and right
	void Flip ()
	{
		if(!wolfDead){
			facingRight = !facingRight;		
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
	}
}
