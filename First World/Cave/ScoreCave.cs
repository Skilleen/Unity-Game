using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/* Scott Killeen, March 24th, 2015
 * Methods for the score and text.
 * 
 * */
public class ScoreCave : MonoBehaviour {
	public Text instruction;
	public int armourLevel = 5;
	public int strengthLevel = 10;
	private int count = 0;
	private bool firstEnter = true; //First time player entered the cave.
	// Use this for initialization
	void Start () {
		instruction = GetComponent<Text>();
		Cursor.visible = false;

		//Enemy Yells when the player enters the cave.
		if(firstEnter){
			firstEnter=false;
			instruction.text="                      \"YOU DIE NOW!\"";
			count=100;
		}

	}
	
	// Update is called once per frame
	void Update () {
		GameObject Dwarf = GameObject.Find("Dwarf");
		DwarfCave dwarfScript = Dwarf.GetComponent<DwarfCave>();
		GameObject Armour = GameObject.Find("Armour");
		ArmourScript armourScript = Armour.GetComponent<ArmourScript>();
		//If the dwarf collides with the sign.

		//If the dwarf collides with the cave.
		if(dwarfScript.caveContact){
			dwarfScript.caveContact=false;
			count=200;
		}
		//If the dwarf collides with the axe.
		else if(armourScript.armourContact){
			armourScript.armourContact=false;
			count=100;
		}
		else if(count==0){

			instruction.text="Health: "+dwarfScript.dwarfLife.ToString("n2")+"   Armour:"+armourLevel+"    Strength:"+strengthLevel;
		}
		if(count>0){
			count--;
		}
		armourScript.armourContact=false;
	}
}
