using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/* Scott Killeen, March 15th, 2015
 * Methods for Dealing with the panel for dialog.
 * 
 * */
public class panelVisible : MonoBehaviour {
	
		CanvasGroup canvasGroup;
		public Button button1; //Two Dialog buttons.
		public Button button2;
		void Awake()
		{
			canvasGroup = GetComponent<CanvasGroup>();
		}
		
		void Start ()
		{
			canvasGroup.alpha=0; //Make the panel invisible

		}

		void Update (){
			GameObject Peasant = GameObject.Find("Peasant");
			NPC_Dialog npc = Peasant.GetComponent<NPC_Dialog>();

			if(npc.displayDialog){
			button1.interactable = true;
			button2.interactable = true;
			canvasGroup.alpha=1;//Show the conversation Panel.
			Cursor.visible=true;
		}
			else{
			canvasGroup.alpha=0;
			Cursor.visible=false;
		}
	}
		
	
	}
