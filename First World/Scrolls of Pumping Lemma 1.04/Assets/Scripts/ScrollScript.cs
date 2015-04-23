using UnityEngine;
using System.Collections;

public class ScrollScript : MonoBehaviour {
	public bool scrollContact = false;
	public bool hasScroll=false;
	private int count = 0; 
	
	//If the user picks up the armour
	void OnCollisionEnter2D(Collision2D col){
		GameObject Behemoth = GameObject.Find("Behemoth");
		BehemothScript behemothScript = Behemoth.GetComponent<BehemothScript>();
		if(col.gameObject.name == "Dwarf" && count == 0 && behemothScript.behemothDead){
			count++;
			GameObject canvas = GameObject.Find("Canvas");
			ScoreCave score = canvas.GetComponent<ScoreCave>();
			GetComponent<Renderer>().enabled = false;
			scrollContact = true;
			score.instruction.text=" You have acquired a scroll of Pumping Lemma!!";
			hasScroll = true;
		}
	}

}
