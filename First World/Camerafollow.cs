using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/* Scott Killeen, March 5th, 2015
 * Methods for the main Camera
 * 
 * */
public class Camerafollow : MonoBehaviour {
	Text instruction; 
	private Transform player;
	
	void Start () {
		player = GameObject.Find("Dwarf").transform;
		instruction = GetComponent<Text>();
	}
	//Have the camera follow the dwarf.
	void Update () {
		Vector3 playerpos = player.position;
		playerpos.z = transform.position.z;
		transform.position = playerpos;
	}
}
