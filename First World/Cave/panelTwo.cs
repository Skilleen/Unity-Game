using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class panelTwo : MonoBehaviour {
	
	CanvasGroup canvasGroup;
	public Button button1; //Two Dialog buttons.
	public Button button2;
	private int count = 200;
	void Awake()
	{
		canvasGroup = GetComponent<CanvasGroup>();
	}
	
	void Start ()
	{
		canvasGroup.alpha=1; //Make the panel invisible
		Cursor.visible=true;

		
	}
	
	void Update (){
		if(count<0){
		GameObject Peasant = GameObject.Find("Peasant");
		NPC_Dialog npc = Peasant.GetComponent<NPC_Dialog>();

		if(npc.displayDialog){
			button1.interactable = true;
			button2.interactable = true;
			canvasGroup.alpha=1;//Show the conversation Panel.
			Cursor.visible=true;
		}
		else{
			Cursor.visible=false;
		}
	}
		count--;
	}
}
