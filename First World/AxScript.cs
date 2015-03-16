using UnityEngine;
using System.Collections;

public class AxScript : MonoBehaviour {
	
	public bool axeContact = false;
	public bool hasAxe = false;
	public int count = 0; 
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.name == "Dwarf" && count == 0){
			count++;
			GameObject sign = GameObject.Find("Canvas");
			Score score = sign.GetComponent<Score>();
			score.strengthLevel=score.strengthLevel+5; 
			GetComponent<Renderer>().enabled = false;
			axeContact = true;
			hasAxe = true;
			score.instruction.text="                                      You have Aquired the Axe of Smite";
		}
	}
}

