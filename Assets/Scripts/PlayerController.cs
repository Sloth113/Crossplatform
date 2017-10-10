using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float hp = 10;
    public float speed = 10;
    public float jumpForce = 5;
    public float fireRate = 0.2f;
    private float fireTimer = 0;
    public GameObject bulletPref;
    


    private CharacterController m_controller;
    private Vector3 m_moveDir;

	// Use this for initialization
	void Start () {
        m_controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        //Movement
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
        //Direction
        //if mouse
        transform.LookAt(getMouseToPlayerPlanePoint());
        //if joystick
        //transform.rotation = Quaternion.Euler(0f, Mathf.Atan2(Input.GetAxis("RightH"), -Input.GetAxis("RightV")) * Mathf.Rad2Deg, 0f);


        fireTimer -= Time.deltaTime;
        //Fire 
        if (ShouldFire()) {
            //Shoot forward
            Instantiate<GameObject>(bulletPref, transform.position, transform.rotation);
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
        if (fireTimer <= 0) {
            //Check inputs 
            //Click or PC, Web
            //Touch for phones (Android, iOS, Windows)
            //Trigger or A for controllers
            fireTimer = fireRate;
            return Input.GetButton("Fire1");

        } else {
            return false;
        }
    }
}
