using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPoint : MonoBehaviour
{
    SpriteRenderer m_SpriteRenderer;
    Gradient gradient;
    GradientColorKey[] colorKey;
    GradientAlphaKey[] alphaKey;
    void Update(){
        transform.position = Camera.main.transform.localPosition + new Vector3(0, 0, 0);
    }
}
