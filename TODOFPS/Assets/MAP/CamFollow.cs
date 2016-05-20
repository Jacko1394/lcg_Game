using UnityEngine;

public class CamFollow : MonoBehaviour {

	public Transform target;
	public float smoothing = 0f;
	private Vector3 offset;
	private bool orth = false;

	void Start () {
		offset = transform.position - target.position;
	}

	void Update () {
		Vector3 goal = target.position + offset;
		transform.position = Vector3.Lerp(transform.position, goal, smoothing * Time.deltaTime);

		if(Input.GetKeyDown(KeyCode.V)) {
			if(orth) {
				GetComponent<Camera>().depth = 0f;

			} else {
				GetComponent<Camera>().depth = 2f;
			}
			orth = !orth;
		}
	}
}//end of class