using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectDestroyer : MonoBehaviour {

	//private BoxCollider coll;

	// Use this for initialization
	void Start () {
		//coll = GetComponent<BoxCollider>();
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag != "Player") {
			Destroy(other.gameObject);
		} else {
			SceneManager.LoadScene(0);
		}
	}
}//end of class
