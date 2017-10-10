using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public GameObject enemyPrefab;
    public float spawnTime = 2;
    public int score;
    private bool inGame;

    public Canvas menuUi;
    public Canvas gameUi;
    private Slider hpSlider;
    private Text scoreTxt;
    public GameObject player;
    private Vector3 startPos;
    
    private float timer;


    public static GameController instance = null;

    void Awake() {
        if (instance == null) {
            instance = this;
        }else if (instance != this) {
            Destroy(gameObject);
        }
    }
	// Use this for initialization
	void Start () {
        inGame = false;
        hpSlider = gameUi.GetComponentInChildren<Slider>();
        scoreTxt = gameUi.GetComponentInChildren<Text>();
        gameUi.enabled = false;
        player.GetComponent<PlayerController>().enabled = false;
        startPos = player.transform.position;
    }
	
	// Update is called once per frame
	void Update () {

        if (inGame) {
            if(player.GetComponent<PlayerController>().hp <= 0) {
                toMenu();
            }
            hpSlider.value = player.GetComponent<PlayerController>().hp;
            scoreTxt.text = "Score : " + score;
            //score

            //enemy spawn
            timer += Time.deltaTime;
            if(timer >= spawnTime) {
                GameObject enemy = Instantiate<GameObject>(enemyPrefab, new Vector3(Random.Range(-50, 55), 1, Random.Range(-60, 36)), new Quaternion());
                enemy.GetComponent<EnemyController>().target = player;
                timer = 0;
            }
            
            
        }
	}

    public void toInGame() {
        score = 0;
        timer = 0;
        inGame = true;
        menuUi.enabled = false;
        gameUi.enabled = true;
        player.GetComponent<PlayerController>().enabled = true;
        player.GetComponent<PlayerController>().hp = 10;
        player.transform.position = startPos;
        
    }

    public void toMenu() {
        inGame = false;
        menuUi.enabled = true;
        gameUi.enabled = false;
        player.GetComponent<PlayerController>().enabled = false;
        
        //Destroy enemies
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy")) {
            Destroy(enemy);
        }
    }

    public void Exit() {
        Application.Quit();
    }
    
}
