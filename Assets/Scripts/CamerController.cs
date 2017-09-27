using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CamerController : MonoBehaviour {
    public GameObject player;
    private Vector3 m_offset;
	// Use this for initialization
	void Start () {
        m_offset = player.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = player.transform.position - m_offset;
        Debug.DrawLine(transform.position, player.transform.position, Color.red);

        if (Input.GetMouseButton(0)) {
            Plane playersYPlane = new Plane(Vector3.up, player.transform.position);
            Vector3 mousePos = Input.mousePosition;
            Ray mouseRay = Camera.main.ScreenPointToRay(mousePos);
            float rayDist = 0;
            playersYPlane.Raycast(mouseRay, out rayDist);
            Vector3 castPoint = mouseRay.GetPoint(rayDist);

            Vector3 toCastPoint = castPoint - player.transform.position;
            Debug.DrawLine(transform.position, castPoint, Color.red);
            Debug.DrawRay(player.transform.position, toCastPoint, Color.black);
        }
    }
}
