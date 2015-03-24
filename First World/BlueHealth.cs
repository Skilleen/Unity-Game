using UnityEngine;
using System.Collections;
/* Created by Scott Killeen, March 23rd, 2015.
 * Methods for dealing with the health gem.
 * */
public class BlueHealth : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//When the player picks up health.
	void OnCollisionEnter2D(Collision2D col){
		GameObject Dwarf = GameObject.Find("Dwarf");
		DwarfMovement dwarfScript = Dwarf.GetComponent<DwarfMovement>();
		if(col.gameObject.name=="Dwarf"){
			Destroy(gameObject);
			if(dwarfScript.dwarfLife<=85f){ //If Less then 85
				dwarfScript.dwarfLife=dwarfScript.dwarfLife+15f;
			}
			else{ //else just give him full health
				dwarfScript.dwarfLife=100f;
			}
		}
	}
}
