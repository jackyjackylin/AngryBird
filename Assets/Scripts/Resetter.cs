using UnityEngine;
using System.Collections;

public class Resetter : MonoBehaviour {

	public Rigidbody2D projectile;
	public float resetSpeed = 0.025f;

	private float resetSpeedSql;
	private SpringJoint2D spring;

	void Start () {
		resetSpeedSql = resetSpeed * resetSpeed;
		spring = projectile.GetComponent<SpringJoint2D> ();
	}
	void Update () {
		if (Input.GetKeyDown (KeyCode.R)) {
			Reset ();
		}
		if (spring==null &&projectile.velocity.sqrMagnitude < resetSpeedSql) {
			Reset ();
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if (other.GetComponent<Rigidbody2D>() == projectile) {
			Reset ();
		}
	}

	void Reset(){
		Application.LoadLevel (Application.loadedLevel);
	}


}
