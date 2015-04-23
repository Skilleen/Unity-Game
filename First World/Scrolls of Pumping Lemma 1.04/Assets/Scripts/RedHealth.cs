using UnityEngine;
using System.Collections;
/* Created by Scott Killeen, March 23rd, 2015.
 * Methods for dealing with the health gem.
 * */
public class RedHealth: MonoBehaviour {


	//When the player picks up the health.
	void OnCollisionEnter2D(Collision2D col){
		GameObject Dwarf = GameObject.Find("Dwarf");
		DwarfMovement dwarfScript = Dwarf.GetComponent<DwarfMovement>();
		DwarfCave dwarfScriptCave = Dwarf.GetComponent<DwarfCave>();
		string level = Application.loadedLevelName; //Check what level the game is on.
		//Health in World one.
		if(col.gameObject.name=="Dwarf" && level =="World One"){
			Destroy(gameObject);
			if(dwarfScript.dwarfLife<=70f){
				dwarfScript.dwarfLife=dwarfScript.dwarfLife+30f; //If health is less than 30.
			}
			else{
				dwarfScript.dwarfLife=100f; //Else just give the player full health.
			}
		}
		//Health in the World one cave.
		if(col.gameObject.name=="Dwarf" && level =="World One Cave"){
			Destroy(gameObject);
			if(dwarfScriptCave.dwarfLife<=70f){
				dwarfScriptCave.dwarfLife=dwarfScriptCave.dwarfLife+30f; //If health is less than 30.
			}
			else{
				dwarfScriptCave.dwarfLife=100f; //Else just give the player full health.
			}
		}
	}
}
