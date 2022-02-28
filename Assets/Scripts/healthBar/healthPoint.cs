using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerMoudle;
public class healthPoint : MonoBehaviour
{
    public static RectTransform rectTransform;

    void Start(){
        rectTransform = GetComponent<RectTransform>();
    }
    void Update(){
        if (Input.GetMouseButton(0)){
            rectTransform.sizeDelta -= new Vector2(0.5f,0);
        }
        else{
            rectTransform.sizeDelta -= new Vector2(0.1f,0);
        }
    }
}
