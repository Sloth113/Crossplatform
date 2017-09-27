using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed = 10;
    public float jumpForce = 5;
    public GameObject bulletPref;


    private CharacterController m_controller;
    private Vector3 m_moveDir;

	// Use this for initialization
	void Start () {
        m_controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        m_moveDir.x = Input.GetAxis("Horizontal") * speed;
        m_moveDir.z = Input.GetAxis("Vertical") * speed;

        if (m_controller.isGrounded) {
            if (Input.GetButton("Jump")) {
                m_moveDir.y += jumpForce;
            }else {
                m_moveDir.y = 0;
            }
        }else {
            m_moveDir.y += Physics.gravity.y *3.14f * Time.deltaTime;
        }

        m_controller.Move(m_moveDir * Time.deltaTime);

        transform.LookAt(getMouseToPlayerPlanePoint());



        //Fire 
        if (ShouldFire()) {
            Vector3 fireDirction = getFireDirection();

            Ray fireRay = new Ray(transform.position, fireDirction);
            RaycastHit rayInfo;

            Instantiate<GameObject>(bulletPref, transform.position, transform.rotation);
            //   Debug.DrawRay(transform.position, fireDirction * 1000, Color.green);
            //if (Physics.Raycast(fireRay, out rayInfo, 1000000)) {
            //    //   print(rayInfo.transform.name);
            //    Instantiate<GameObject>(bulletPref, transform.position, transform.rotation);
            //}
        }





    }

    private Vector3 getMouseToPlayerPlanePoint() {
        Vector3 mousePos = Input.mousePosition;
        Ray mouseRay = Camera.main.ScreenPointToRay(mousePos);

        Plane playersYPlane = new Plane(Vector3.up, transform.position);
        float rayDist = 0;

        playersYPlane.Raycast(mouseRay, out rayDist);

        Vector3 castPoint = mouseRay.GetPoint(rayDist);
        return castPoint;
    }

    private Vector3 getFireDirection() {

        Vector3 toCastPoint = getMouseToPlayerPlanePoint() - transform.position;
        toCastPoint.Normalize();

        return toCastPoint;


    }

    bool ShouldFire() {
         return Input.GetMouseButtonDown(0);
        //return Input.GetMouseButton(0);
    }
}
