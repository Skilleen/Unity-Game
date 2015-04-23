using UnityEngine;
using System.Collections;

public class BabaSign : MonoBehaviour {

	public Collider Dwarf;
	void onTriggerEnter2D (Collider other)
	{

			Debug.Log("swagCity");
			Destroy(other.gameObject);

	}
}
