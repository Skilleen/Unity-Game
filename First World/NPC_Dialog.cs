using UnityEngine;
using System.Collections;
/* Scott Killeen, March 15th, 2015
 * Methods for Dealing with NPC conversations
 * 
 * */
public class NPC_Dialog : MonoBehaviour {
	public float range = 0; //check if the player is in range
	public bool displayDialog = false; //If the conversation box is shown.
	public Transform target;
	public bool questAccept = false; //If the user accepted.
	public Rigidbody2D rb;


	
	// Update is called once per frame
	void Update () {
		//If the player has moved away
		range = Vector2.Distance(transform.position, target.position);
		if(range >=5){
			displayDialog=false;
			Cursor.visible=false;
		}
		rb = GetComponent<Rigidbody2D>();
		if(rb.mass==2){
			questAccept=true;
		}
	}


	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.name == "Dwarf"){
			displayDialog=true;

		}
}
}
