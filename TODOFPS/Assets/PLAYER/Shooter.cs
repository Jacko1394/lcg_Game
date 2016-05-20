using UnityEngine;

public class Shooter : MonoBehaviour {

	public GameObject bullet;
	public float rate, speed, lifetime;
    private bool shooting = false;

	void Update () {
		if(Input.GetAxisRaw("Shoot") != 0f) {
            if(!shooting) {
                InvokeRepeating("Fire", 0f, rate);
                shooting = true;
            }
		} else {
			CancelInvoke();
            shooting = false;
		}
	}

	void Fire() {
		bullet.GetComponent<Bullet>().speed = speed;
		bullet.GetComponent<Bullet>().lifetime = lifetime;
		Instantiate(bullet, transform.position, transform.rotation);
	}
}//end of class