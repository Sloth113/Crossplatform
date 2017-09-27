using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedThingOne : MonoBehaviour {
    private Vector3 m_spawn;
    private Rigidbody m_rigidbody;
	// Use this for initialization
	void Start () {
        m_spawn = transform.position;
        m_rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y < -2) {
            transform.position = m_spawn;
            m_rigidbody.velocity = new Vector3();
        }
	}
}
