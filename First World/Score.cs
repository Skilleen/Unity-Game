using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/* Scott Killeen, March 10th, 2015
 * Methods for the score and text.
 * 
 * */
public class Score : MonoBehaviour {
	public Text instruction;
	public int armourLevel = 5;
	public int strengthLevel = 10;
	public int count = 0;
	// Use this for initialization
	void Start () {
		instruction = GetComponent<Text>();
		//Screen.lockCursor = false;
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		GameObject Dwarf = GameObject.Find("Dwarf");
		DwarfMovement dwarfScript = Dwarf.GetComponent<DwarfMovement>();
		GameObject Axe = GameObject.Find("Axe");
		AxScript axScript = Axe.GetComponent<AxScript>();
		//If the dwarf collides with the sign.
		if(dwarfScript.signContact){
			dwarfScript.signContact = false;
			count=100;
		}
		//If the dwarf collides with the cave.
		else if(dwarfScript.caveContact){
			dwarfScript.caveContact=false;
			count=200;
		}
		//If the dwarf collides with the axe.
		else if(axScript.axeContact){
			axScript.axeContact=false;
			count=100;
		}
		else if(dwarfScript.signContact==false && count==0){

		instruction.text="Health: "+dwarfScript.dwarfLife.ToString("n2")+"   Armour:"+armourLevel+"    Strength:"+strengthLevel;
		}
		if(count>0){
			count--;
		}
		axScript.axeContact=false;
	}

}
