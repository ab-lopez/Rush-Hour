using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneSwitch : MonoBehaviour
{
	public GameObject train;
	private AudioSource metroNoise;


    void Awake()
    {
        metroNoise = train.GetComponent<AudioSource>();
		Debug.Log("triggered");
    }

    public void LoadGameScene()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
	}

    public void LoadEndGame()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
	}

	public void LoadGoodEnd(){
		UnityEngine.SceneManagement.SceneManager.LoadScene("GameWon");
	}

	public void playNoise(){
			metroNoise.Play();	
	}
}
