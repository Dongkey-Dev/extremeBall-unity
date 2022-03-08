using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour
{
    public Text pointsText;
    public void Setup(int score){
        gameObject.SetActive(true);
        pointsText.text = "Point : " + score.ToString();
    }
    public void Restart(){
        SceneManager.LoadScene("MainScene");
    }

    void Update(){
        if(Input.anyKey){
            Restart();
        }
    }
}
