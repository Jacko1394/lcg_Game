using UnityEngine;

public class Bullet : MonoBehaviour {

	[HideInInspector] public float speed, lifetime;

	void Start () {
		Invoke("Kill", lifetime);
		GetComponent<Rigidbody>().velocity = transform.forward * speed;
	}

	void Kill() {
		Destroy(gameObject);
	}
}//end of class