using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerMoudle;
public class healthPoint : MonoBehaviour
{
    public static RectTransform rectTransform;
    int InitHealthUIWidth = 20;
    void Start(){
        rectTransform = GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(playerStatus.currentHP, InitHealthUIWidth);
    }
    void FixedUpdate(){
        rectTransform.sizeDelta = new Vector2(playerStatus.currentHP, InitHealthUIWidth);
    }
}
