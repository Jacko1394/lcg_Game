using UnityEngine;

public class FPSRigid : MonoBehaviour {

	[Range(0, 10)] public float topSpeed;
	[Range(0, 10)] public float jumpSpeed;
	[Range(0, 10)] public float rotSpeed;

	private Rigidbody rb;
	private Vector3 moveDirection = Vector3.zero;
	private float rotX, rotY = 0f;
	private bool grounded = false;

	// Use this for initialization
	void Start () {
		topSpeed += 5;
		rb = GetComponent<Rigidbody>();
		Cursor.visible = false;
	}
	
	void Update() {
		
	}

	
	void FixedUpdate() {
		rotX = Input.GetAxis("Mouse X") * rotSpeed;
		rotY = Input.GetAxis("Mouse Y") * rotSpeed;

		transform.Rotate(0f, 0f, rotX);
		Camera.main.transform.Rotate(rotY, 0f, 0f);
		moveDirection.x = Input.GetAxis("Horizontal") * topSpeed;
		moveDirection.z = Input.GetAxis("Vertical") * topSpeed;
		
		

		if(grounded && Input.GetButton("Fire1")) {
			moveDirection.y = jumpSpeed;
		} else {
			moveDirection.y = rb.velocity.y;
		}

		rb.velocity = moveDirection;
		
		
		
		
		
		
		/*
		Quaternion temp = new Quaternion();
		temp = rb.rotation;

		temp.z = turnDirection;
		rb.rotation = temp;


		Debug.Log("temp: " + temp);

		*/





		//moveDirection = transform.TransformDirection(moveDirection);
		//moveDirection *= topSpeed;
		//rb.MovePosition(moveDirection);

		

	}

	void OnCollisionEnter() {
		grounded = true;
	}
	void OnCollisionExit() {
		grounded = false;
	}

	

}//end of class