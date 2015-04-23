using UnityEngine;
using System.Collections;

public class PeasentFriendScript : MonoBehaviour {
	public bool friendContact=false;

	void OnCollisionEnter2D(Collision2D col){
		GameObject canvas = GameObject.Find("Canvas");
		ScoreCave score = canvas.GetComponent<ScoreCave>();
		if(col.gameObject.name == "Dwarf"){
			score.instruction.text="           The Boatman's friend is dead.";
			friendContact=true;
			
		}
	}
}
