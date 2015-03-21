using UnityEngine;
using System.Collections;

public class BlueHealth : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(Collision2D col){
		GameObject Dwarf = GameObject.Find("Dwarf");
		DwarfMovement dwarfScript = Dwarf.GetComponent<DwarfMovement>();
		if(col.gameObject.name=="Dwarf"){
			Destroy(gameObject);
			if(dwarfScript.dwarfLife<=85f){
				dwarfScript.dwarfLife=dwarfScript.dwarfLife+15f;
			}
			else{
				dwarfScript.dwarfLife=100f;
			}
		}
	}
}
