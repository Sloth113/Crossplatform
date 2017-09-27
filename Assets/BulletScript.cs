using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
    private Vector3 m_startPos;
    public float lifeDist = 100;
    public float speed = 50;
	// Use this for initialization
	void Start () {
        m_startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if((transform.position - m_startPos).magnitude >= lifeDist){
            Destroy(gameObject);
        }else {
            transform.position += transform.forward * Time.deltaTime * speed;
        }
	}
}
