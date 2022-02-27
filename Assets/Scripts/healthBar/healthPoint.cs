using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerMoudle;
public class healthPoint : MonoBehaviour
{
    SpriteRenderer m_SpriteRenderer;
    Gradient gradient;
    GradientColorKey[] colorKey;
    GradientAlphaKey[] alphaKey;
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_SpriteRenderer.material.SetColor("_Color", Color.red);
        transform.position = Camera.main.transform.position;
    }
}
