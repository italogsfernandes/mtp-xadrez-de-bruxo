using UnityEngine;
using System.Collections;

public class Desmarcar : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Destroy (gameObject);
		}
	}
}
