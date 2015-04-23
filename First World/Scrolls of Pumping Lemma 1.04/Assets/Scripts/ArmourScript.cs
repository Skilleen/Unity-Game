using UnityEngine;
using System.Collections;
/* Scott Killeen, March 26th, 2015
 * Methods for the armour
 * 
 * */
public class ArmourScript : MonoBehaviour {
	public bool armourContact = false;
	public bool hasArmour = false;
	private int count = 0; 

	//If the user picks up the armour
	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.name == "Dwarf" && count == 0){
			count++;
			GameObject canvas = GameObject.Find("Canvas");
			ScoreCave score = canvas.GetComponent<ScoreCave>();
			score.armourLevel=score.armourLevel+3; 
			GetComponent<Renderer>().enabled = false;
			armourContact = true;
			hasArmour = true;
			score.instruction.text=" You have Aquired a Iron Breast Plate (Armour +3)";
		}
	}
}
