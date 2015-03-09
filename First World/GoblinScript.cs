using UnityEngine;
using System.Collections;
/* Scott Killeen, March 5th, 2015
 * Methods for Dealing with the movements and animations of the Goblin (Enemy)
 * 
 * */
public class GoblinScript : MonoBehaviour {
	//Variables for getting the goblin to follow the Player and to react to animations.
	public Transform target;
	public float speed = 3f;
	private float minDistance = 1f;
	private float maxDistance = 30f;
	private float attackDistance = 5f;
	private float range;
	public bool goblinDead=false;
	public bool goblinDead1=false;
	public bool doDamage=false;
	public bool playerHit=false;
	public bool inRange=false;
	public float goblinLife=50f; 


	Animator anim;
	void Start () {
		anim = GetComponent<Animator>();
	}
	private bool facingRight=true;

	void FixedUpdate ()
	{	
		GameObject Dwarf = GameObject.Find("Dwarf");
		DwarfMovement dwarfScript = Dwarf.GetComponent<DwarfMovement>();

		doDamage=false;
		playerHit=false;
		//To find and move to the Player
		float myposition = transform.position.x;
		float dwarfposition = target.position.x;
		float h = Input.GetAxis("Horizontal");
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
		if(goblinLife<=0){
			anim.SetBool("dead",true);
			anim.SetBool("attack", false);
			anim.SetBool("walk", false);
			anim.SetBool("hit", false);
			speed = 0f;
			goblinDead=true;
		}
	}
	//Handles Collisions
	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.name == "Dwarf" && !goblinDead){
			anim.SetBool("attack",true);
			if (range < attackDistance){
				playerHit = true;
			}

		}

	}
	//To face left and right
	void Flip ()
	{
		if(!goblinDead){
		facingRight = !facingRight;		
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	}

	}
	


