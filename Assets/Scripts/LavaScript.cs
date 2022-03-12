using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaScript : MonoBehaviour
{
 public GameObject box;
     void Start()
     {
        BoxCollider2D bc = box.GetComponent<BoxCollider2D> ();
        RectTransform rect = box.GetComponent<RectTransform> ();
        bc.size = new Vector2 (rect.sizeDelta.x, rect.sizeDelta.y);
        bc.isTrigger = true;
     }
}
