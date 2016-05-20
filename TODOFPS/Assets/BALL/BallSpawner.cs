using UnityEngine;

public class BallSpawner : MonoBehaviour {

	public float rate;
	public GameObject balls;
	
	void Start () {
		InvokeRepeating("Spawn", 1f, rate);
	}
	void Spawn() {
		GameObject.Instantiate(balls, transform.position, Quaternion.identity);
	}
}//end of class