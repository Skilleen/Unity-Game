using UnityEngine;
using System.Collections;
/* Scott Killeen, March 5th, 2015
 * Methods for Dealing with the movements and animations of the Wolf Rider.
 * 
 * */
public class WolfScript : MonoBehaviour {

	public Transform target;
	public float speed = 3f;
	public float maxDistance = 30f;
	public float attackDistance = 5f;
	public float range;
	public bool wolfDead=false;
	public bool doDamage=false;
	public bool playerHit=false;
	public bool inRange=false;
	public float wolfLife=100f;
	public bool facingRight=true;
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
			anim.SetBool("dead",true);
			anim.SetBool("attack", false);
			anim.SetBool("walk", false);
			speed = 0f;
			wolfDead=true;
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
