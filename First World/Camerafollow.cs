using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/* Scott Killeen, March 5th, 2015
 * Methods for the main Camera
 * 
 * */
public class Camerafollow : MonoBehaviour {
	private Transform player;
	
	void Start () {
		player = GameObject.Find("Dwarf").transform;
	}
	//Have the camera follow the dwarf.
	void Update () {
		Vector3 playerpos = player.position;
		playerpos.z = transform.position.z;
		transform.position = playerpos;
		//Quit Game
		if (Input.GetKey(KeyCode.Escape)) {
			Application.Quit(); 
		}
	}
}
