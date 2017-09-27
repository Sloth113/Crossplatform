using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {
    public enum State {
        Menu,
        Playing,
        Over
    }
    public State currentState;
    //UI
    public Canvas menuUi;
    public Canvas inGameUi;
    public Canvas gameOverUi;

    //objects
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;
    public GameObject prefab4;




    // Use this for initialization
    void Start () {
#if UNITY_EDITOR
        Debug.Log("Hi");
#endif
#if UNITY_PS4
        Debug.Log("PS4");
#endif
        currentState = State.Menu;
        menuUi.enabled = true;
        inGameUi.enabled = false;
        gameOverUi.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

		if(currentState == State.Playing) {
            //spawn the objects put in a list

            if (Input.GetMouseButtonDown(0)) {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit rayHit;

                if (Physics.Raycast(ray, out rayHit)) {
                    //CHECK rayhit to what it hit
                    Debug.Log(rayHit.transform.name);

                }
            }
        }
	}

    public void toPlaying() {
        currentState = State.Playing;
        menuUi.enabled = false;
        gameOverUi.enabled = false;
        inGameUi.enabled = true;
    }

    public void toMenu() {
        currentState = State.Menu;
        menuUi.enabled = true;
        gameOverUi.enabled = false;
        inGameUi.enabled = false;
    }

    public void toGameOver() {
        currentState = State.Over;
        menuUi.enabled = false;
        gameOverUi.enabled = true;
        inGameUi.enabled = false;
    }
}
