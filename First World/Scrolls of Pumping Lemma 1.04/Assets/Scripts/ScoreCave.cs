using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/* Scott Killeen, March 24th, 2015
 * Methods for the score and text.
 * 
 * */
public class ScoreCave : MonoBehaviour {
	public Text instruction;
	public int armourLevel;
	public int strengthLevel;
	private int count = 0;
	private bool firstEnter = true; //First time player entered the cave.
	// Use this for initialization
	void Start () {
		instruction = GetComponent<Text>();
		Cursor.visible = false;
		armourLevel = PlayerPrefs.GetInt("armour");
		strengthLevel = PlayerPrefs.GetInt("strength");

		//Enemy Yells when the player enters the cave.
		if(firstEnter){
			firstEnter=false;
			instruction.text="                      \"YOU DIE NOW!\"";
			count=100;
		}

	}
	
	// Update is called once per frame
	void Update () {
		PlayerPrefs.SetInt("strength", strengthLevel);
		PlayerPrefs.SetInt ("armour",armourLevel);
		GameObject Dwarf = GameObject.Find("Dwarf");
		DwarfCave dwarfScript = Dwarf.GetComponent<DwarfCave>();
		GameObject Armour = GameObject.Find("Armour");
		ArmourScript armourScript = Armour.GetComponent<ArmourScript>();
		GameObject Scroll = GameObject.Find("Scroll");
		ScrollScript scrollScript = Scroll.GetComponent<ScrollScript>();
		GameObject friend = GameObject.Find("PeasentFriend");
		PeasentFriendScript peasentFriendScript = friend.GetComponent<PeasentFriendScript>();
		//If the dwarf collides with the sign.

		//If the dwarf collides with the cave.
		if(dwarfScript.caveContact){
		dwarfScript.caveContact=false;
		count=100;
	}
		//If the dwarf collides with the axe.
		if(armourScript.armourContact){
			armourScript.armourContact=false;
			count=200;
		}
		if(scrollScript.scrollContact){
			scrollScript.scrollContact=false;
			count=200;
		}
		if(peasentFriendScript.friendContact){
			peasentFriendScript.friendContact=false;
			count = 200;
		}
		if(dwarfScript.caveContact){
			dwarfScript.caveContact=false;
			count=200;
		}
		else if(count==0){

			instruction.text="Health: "+dwarfScript.dwarfLife.ToString("n2")+"   Armour:"+PlayerPrefs.GetInt("armour")+"    Strength:"+PlayerPrefs.GetInt("strength");;
		}
		if(count>0){
			count--;
		}
		armourScript.armourContact=false;
	}
}
