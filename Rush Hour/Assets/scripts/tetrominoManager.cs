using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tetrominoManager : MonoBehaviour
{
    // array of tetronimo prefabs
    public GameObject[] tetronimoPrefabs;
    private GameObject currentTetronimo;
    private GameObject newTetromino;

    private tetronimo respawn;
    private int initialSpawn = 10;

    int index;

    public int tetronimosLeft;

    //tetronimoI, tetronimoJ, tetronimoL, tetrominoO, tetrominoS, tetrominoT, tetrominoZ;

    // Start is called before the first frame update
    void Awake()
    {
        tetronimosLeft = 15;

        // spawn initial ones for player to fit in
        for(int i = 0; i < initialSpawn; i++){
             index = Random.Range (0, tetronimoPrefabs.Length);
             currentTetronimo = tetronimoPrefabs[index];
            int xPosGen = Random.Range(-7, 4);
            int yPosGen = 3;

            newTetromino = Instantiate(currentTetronimo, new Vector3(xPosGen,yPosGen,0), Quaternion.identity);
            respawn = newTetromino.GetComponent<tetronimo>();
            respawn.placed = true;
        }

        // spawn first tetronimo to be placed
        spawnTetronimo();
        respawn = newTetromino.GetComponent<tetronimo>();
    }

    void Update(){
        
        if(this.respawn.placed){
            tetronimosLeft -=1;

            spawnTetronimo();
            respawn = newTetromino.GetComponent<tetronimo>();
        }

    }

    void spawnTetronimo()
    {
        index = Random.Range (0, tetronimoPrefabs.Length);
        currentTetronimo = tetronimoPrefabs[index];
        Debug.Log("hello i'm spawning... " + currentTetronimo.name);

        newTetromino = Instantiate(currentTetronimo, new Vector3(11,9,0), Quaternion.identity);
    }
}
