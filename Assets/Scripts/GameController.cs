using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class GameController : MonoBehaviour {

    public float spawnInterval;
    public int difficulty;
    public Transform playerPosition;
    public Transform[] spawnPoints;
    public AICharacterControl basicEnemy;

    // Use this for initialization
    void Start () {
        InvokeRepeating("SpawnBasic", spawnInterval * difficulty, spawnInterval * difficulty);
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void SpawnBasic() {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        AICharacterControl spawn = (AICharacterControl) Instantiate(basicEnemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        spawn.target = playerPosition;
    }
}
