using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {
    public static MusicPlayer instance = null;
    public static AudioLowPassFilter audioLowPassFilter;

    void Start()
    {
        audioLowPassFilter = GetComponent<AudioLowPassFilter>();
    }
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }
}