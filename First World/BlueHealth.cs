using UnityEngine;
using System.Collections;
/* Created by Scott Killeen, March 23rd, 2015.
 * Methods for dealing with the health gem.
 * */
public class BlueHealth : MonoBehaviour {


	//When the player picks up health.
	void OnCollisionEnter2D(Collision2D col){
		GameObject Dwarf = GameObject.Find("Dwarf");
		DwarfMovement dwarfScript = Dwarf.GetComponent<DwarfMovement>();
		DwarfCave dwarfScriptCave = Dwarf.GetComponent<DwarfCave>();
		string level = Application.loadedLevelName; //Check what level the game is on.
		//For World One
		if(col.gameObject.name=="Dwarf" && level == "World One"){
			Destroy(gameObject);
			if(dwarfScript.dwarfLife<=85f){ //If Less then 85
				dwarfScript.dwarfLife=dwarfScript.dwarfLife+15f;
			}
			else{ //else just give him full health
				dwarfScript.dwarfLife=100f;
			}
		}
		//Health in the World one cave.
		if(col.gameObject.name=="Dwarf" && level =="World One Cave"){
			Destroy(gameObject);
			if(dwarfScriptCave.dwarfLife<=85f){
				dwarfScriptCave.dwarfLife=dwarfScriptCave.dwarfLife+15f; //If health is less than 30.
			}
			else{
				dwarfScriptCave.dwarfLife=100f; //Else just give the player full health.
			}
		}
	}
}
