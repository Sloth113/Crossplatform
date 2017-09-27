using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class basicController : MonoBehaviour {
    private Rigidbody m_rigidbody;
	// Use this for initialization
	void Start () {
        m_rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        
        m_rigidbody.AddForce(new Vector3(Input.GetAxis("Vertical") * 50, 0, Input.GetAxis("Horizontal") * -50));
        if(Input.GetAxis("Jump") > 0) {
            transform.position = new Vector3(0, 10, 0);
            m_rigidbody.velocity = new Vector3(0, 0, 0);
        }
	}
}
