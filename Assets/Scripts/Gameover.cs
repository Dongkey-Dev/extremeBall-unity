using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour
{
    public Text pointsText;
    public void Setup(int score){
        pointsText.text = "Point : " + score.ToString();
        gameObject.SetActive(true);
        
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
