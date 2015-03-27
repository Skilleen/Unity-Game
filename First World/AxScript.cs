using UnityEngine;
using System.Collections;
/* Scott Killeen, March 19th, 2015
 * Methods for the axe
 * 
 * */
public class AxScript : MonoBehaviour {
	
	public bool axeContact = false;
	public bool hasAxe = false;
	private int count = 0; 
	

	//If the dwarf picks up the axe.
	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.name == "Dwarf" && count == 0){
			count++;
			GameObject sign = GameObject.Find("Canvas");
			Score score = sign.GetComponent<Score>();
			score.strengthLevel=score.strengthLevel+5; 
			GetComponent<Renderer>().enabled = false;
			axeContact = true;
			hasAxe = true;
			score.instruction.text=" You have Aquired the Axe of Smite (Strength +5)";
		}
	}
}

