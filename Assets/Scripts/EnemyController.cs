using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public GameObject target;
    private CharacterController controller;
    public float speed = 5;
	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        //Move towards
		if(target != null) {

            //If close enough explode
            if ((target.transform.position - this.transform.position).magnitude < 1.7f) {
                target.GetComponent<PlayerController>().hp--;
                //Enemy destroy particles
                //Remove 2 score for being hit
                GameController.instance.score-= 2;
                Destroy(this.gameObject);
            }

            controller.Move((target.transform.position - this.transform.position).normalized * speed * Time.deltaTime);
        }
	}
    void OnDestroy() {
        //Increase score here as on collision registers multiple
        GameController.instance.score++;
    }
}
