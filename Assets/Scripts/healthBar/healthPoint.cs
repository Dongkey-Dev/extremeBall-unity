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
        rectTransform.sizeDelta = new Vector2(playerHP.maxHP, 20);
    }
    void FixedUpdate(){
        rectTransform.sizeDelta = new Vector2(playerHP.currentHP, 20);
    }
}
