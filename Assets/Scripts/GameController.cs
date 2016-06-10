using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public float spawnInterval;
    public int difficulty;
    public Transform playerPosition;
    public Transform[] spawnPoints;
    public AICharacterControl basicEnemy;
    public Text score;

    static int scoreNumber = 0;

    // Use this for initialization
    void Start () {
        InvokeRepeating("SpawnBasic", spawnInterval * difficulty, spawnInterval * difficulty);
        score.text = scoreNumber.ToString();
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    void SpawnBasic() {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        AICharacterControl spawn = (AICharacterControl) Instantiate(basicEnemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        spawn.target = playerPosition;
        spawn.controller = this;
    }

    public void IncreaseScore(int increase) {
        scoreNumber += increase;
        score.text = scoreNumber.ToString();
    }
}
