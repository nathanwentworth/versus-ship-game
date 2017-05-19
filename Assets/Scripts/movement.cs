using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {

	public float speed = 110f; 
	public float turnSpeed = 3.5f; 
	public float hoverForce = 6.5f; 
	public float hoverHeight = 3.5f;

	private float powerInput;
	private Rigidbody carRigidbody; 
	private bool qPress;
	private bool ePress;
	private bool aPress;
	private bool dPress;

	void Awake () {
		carRigidbody = GetComponent <Rigidbody>();
	}
	
	void Update () {

		if (Input.GetKey("q")) {
			qPress = true;
		}
		else {
			qPress = false;
		}

		if (Input.GetKey("e")) {
			ePress = true;
		}
		else {
			ePress = false;
		}

		if (Input.GetKey("a")) {
			aPress = true;
		}
		else {
			aPress = false;
		}

		if (Input.GetKey("d")) {
			dPress = true;
		}
		else {
			dPress = false;
		}
	}

	void FixedUpdate () {
		Ray ray = new Ray (transform.position, -transform.up);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, hoverHeight)) {
			float proportionalHeight = (hoverHeight - hit.distance) / hoverHeight;
			Vector3 appliedHoverForce = Vector3.up * proportionalHeight * hoverForce;
			carRigidbody.AddForce(appliedHoverForce, ForceMode.Acceleration);
		}

		if (qPress == true) {
			carRigidbody.AddRelativeTorque(0f, 1 * turnSpeed, 0f);
		}
		if (ePress == true) {
			carRigidbody.AddRelativeTorque(0f, -1 * turnSpeed, 0f);
		}
		if (qPress == true && ePress == true) {
			carRigidbody.AddRelativeForce(0f, 0f, 1 * speed);
		}
		if (aPress == true) {
			carRigidbody.AddRelativeTorque(0f, 1 * turnSpeed, 0f);
		}
		if (dPress == true) {
			carRigidbody.AddRelativeTorque(0f, -1 * turnSpeed, 0f);
		}
		if (aPress == true && dPress == true) {
			carRigidbody.AddRelativeForce(0f, 0f, -1 * speed);
		}
		if (aPress == true && ePress == true) {
			carRigidbody.AddRelativeTorque(0f, -2 * turnSpeed, 0f);
		}
		if (qPress == true && dPress == true) {
			carRigidbody.AddRelativeTorque(0f, 2 * turnSpeed, 0f);
		}

		// carRigidbody.AddRelativeForce(0f, 0f, powerInput * speed);
		// carRigidbody.AddRelativeTorque(0f, turnInput * turnSpeed, 0f);
	}
}
