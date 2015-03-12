using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
		if(dwarfScript.signContact){
			dwarfScript.signContact = false;
			count=100;
		}
		else if(dwarfScript.signContact==false && count==0){

		instruction.text="Health: "+dwarfScript.dwarfLife.ToString("n2")+"   Armour:"+armourLevel+"    Strength:"+strengthLevel;
		}
		if(count>0){
			count--;
		}
	}

}
