using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/* Scott Killeen, March 15th, 2015
 * Dealing with the buttons.
 * 
 * */
public class ButtonText : MonoBehaviour {
	public int dialogCount = 0;
	public Button button1;
	public Button button2;
	// Use this for initialization
	void Start () {
		button1.GetComponentInChildren<Text>().text = "I am Kai of the Baba Clan. May I use your boat?";
		button2.GetComponentInChildren<Text>().text = "I will see what I can do.";
	}

}
