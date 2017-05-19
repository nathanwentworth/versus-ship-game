using UnityEngine;
using System.Collections;

public class shooting : MonoBehaviour {
	
	RaycastHit hit;

	void Update () {

		GameObject p1car = GameObject.Find("p1car");
        p1health p1health = p1car.GetComponent<p1health>();

		if (Input.GetButtonDown("Fire1")) {
            Vector3 fwd = transform.TransformDirection(Vector3.forward);
        	// RaycastHit hit;
        	if (Physics.Raycast(transform.position, fwd, 1000)) {
            	Debug.DrawLine(fwd,hit.point,Color.green);
            	print("Hit");
            	p1health.healthp1 -= 10;
            	print(p1health.healthp1);
        	}
        }
	}
}
