using UnityEngine;
using System.Collections;
/* Scott Killeen, March 15th, 2015
 * Methods for Dealing with NPC conversations
 * 
 * */
public class NPC_Dialog : MonoBehaviour {
	public float range = 0; //check if the player is in range
	public bool displayDialog = false;
	public Transform target;


	
	// Update is called once per frame
	void Update () {
		range = Vector2.Distance(transform.position, target.position);
		if(range >=5){
		displayDialog=false;
		}
	}


	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.name == "Dwarf"){
			displayDialog=true;
		}
}
}
