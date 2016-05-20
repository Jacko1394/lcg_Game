using UnityEngine;

public class FPSMovement : MonoBehaviour {
	[Range(0, 10)]
	public float topSpeed, jumpSpeed, rotSpeed, gravity;
	[Range(10, 90)]
	public float lookUpLimit;
	[Range(-10, -90)]
	public float lookDownLimit;

	private CharacterController cc;
	private float fallSpeed = 0f;
	private float leftRight, upDown = 0f;
	
	void Start() {
		topSpeed += 5;
		cc = GetComponent<CharacterController>();
		leftRight = transform.rotation.eulerAngles.y;			//Initializes from starting rotation.
		Cursor.visible = false;								//Hides mouse.
	}
	
	void Update() {
		//Rotation:
		float rotX = Input.GetAxis("leftright") * rotSpeed;			//left-right
		float rotY = Input.GetAxis("updown") * rotSpeed;			//up-down
		leftRight += rotX;											//Updates direction vector based on spin.
		upDown += rotY;												//Updates camera up-down rotation.
		transform.Rotate(0f, rotX, 0f);								//player spin
		upDown = Mathf.Clamp(upDown, lookDownLimit, lookUpLimit);	//Limits up-down look range.
		//Sets new main camera rotation based on these updates:
		Camera.main.transform.rotation = Quaternion.Euler(upDown, leftRight, Camera.main.transform.rotation.z);

		//Gravity/Jumping:
		if(cc.isGrounded) {
			if(Input.GetAxis("Jump") != 0f) {
				fallSpeed = jumpSpeed;				//Applies jump force, if grounded.
			} else {
				fallSpeed = 0f;						//Not falling/jumping, if grounded & not jumping.
			}
		} else {
            if (Input.GetAxisRaw("fly") != 0f) {
                fallSpeed = jumpSpeed * 2;
            } else {
                fallSpeed -= gravity * Time.deltaTime;	//If not grounded, apply gravity.
            }
		}

		//Movement:
		Vector3 moveDirection;
		moveDirection.x = Input.GetAxis("A and D") * topSpeed;      //left-right
		moveDirection.y = fallSpeed;								//gravity-jumping
		moveDirection.z = Input.GetAxis("W and S") * topSpeed;		//foward-back

		//Rotates move direction with player spin:
		moveDirection = Quaternion.AngleAxis(leftRight, Vector3.up) * moveDirection;
		
		//Applies motion to character:
		cc.Move(moveDirection * Time.deltaTime);
	}
}//end of class