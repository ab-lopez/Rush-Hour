using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class gameManager : MonoBehaviour
{
    public GameObject tManager;
    private tetrominoManager tmScript;
    public TMP_Text peopleLeftDisplay, timerDisplay;
    private float tetronimoCounter;
    float timeLeft = 100;
   // float r=226f,g=51f,b=;29f

    [SerializeField] GameObject train;
    private Animator animatorController;

    // Start is called before the first frame update
    void Start()
    {
        tmScript = tManager.GetComponent<tetrominoManager>();
        animatorController = train.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        tetronimoCounter = tmScript.tetronimosLeft;

        timeLeft -= Time.deltaTime;

        peopleLeftDisplay.text = (tetronimoCounter.ToString() + " people left.");
       
        if(timeLeft <= 1){
            timerDisplay.text = ("Time's up!");
            timerDisplay.fontSize = 72;
        }
        else{
            timerDisplay.text = (((int)timeLeft).ToString());
        }

        if (timeLeft < 11){
            timerDisplay.color= Color.red;
            Debug.Log("RED");
        }

        if (timeLeft <= 0 || tetronimoCounter == 0){
            GameOver();
        }
    }

    void GameOver(){
        if(tetronimoCounter==0){
            animatorController.SetBool("playGood", true);
        }
        else{
           animatorController.SetBool("playEnd", true);

        }
    }
}
