using UnityEngine;
using System.Collections;

public class PlayerFollow : MonoBehaviour {

	public Transform target;
	private NavMeshAgent nav;

	// Use this for initialization
	void Start () {
		nav = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {

		if(Vector3.Distance(transform.position, target.position) > 1.8f) {
			nav.SetDestination(target.position);
		} else {
			nav.SetDestination(transform.position);
		}

	}
}
