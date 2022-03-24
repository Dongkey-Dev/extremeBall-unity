using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ChromaticController : MonoBehaviour
{
    ChromaticAberration chromatic;
    PostProcessVolume volumeChromatic;
    void Start()
    {
        chromatic = ScriptableObject.CreateInstance<ChromaticAberration>();
        chromatic.enabled.Override(true);
        chromatic.intensity.Override(.35f);
        volumeChromatic = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, chromatic);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetMouseButton(0)){
            chromatic.intensity.value = .65f;
        }
        else{
            chromatic.intensity.value = .30f;
        }
    }
}
