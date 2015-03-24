using UnityEngine;
using System.Collections;
/* Created by Scott Killeen, March 23rd, 2015.
 * Methods for dealing with the health gem.
 * */
public class RedHealth : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	//When the player picks up the health.
	void OnCollisionEnter2D(Collision2D col){
		GameObject Dwarf = GameObject.Find("Dwarf");
		DwarfMovement dwarfScript = Dwarf.GetComponent<DwarfMovement>();
		if(col.gameObject.name=="Dwarf"){
			Destroy(gameObject);
			if(dwarfScript.dwarfLife<=70f){
				dwarfScript.dwarfLife=dwarfScript.dwarfLife+30f; //If health is less than 30.
			}
			else{
				dwarfScript.dwarfLife=100f; //Else just give the player full health.
			}
		}
	}
}
