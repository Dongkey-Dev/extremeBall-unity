using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ChangeOrthosize : MonoBehaviour
{
    float PlayerMagnitude;
    public CinemachineVirtualCamera vcam;

    void Start(){
        vcam.m_Lens.OrthographicSize = 8;
    }    
    void FixedUpdate(){
        PlayerMagnitude = ShootToMouse.PlayerVelocity.magnitude;
        if(PlayerMagnitude > 15){
            vcam.m_Lens.OrthographicSize = Mathf.Max(8, Mathf.Min(vcam.m_Lens.OrthographicSize+0.2f, 20));
        }
        else{
            vcam.m_Lens.OrthographicSize = Mathf.Max(8, Mathf.Min(vcam.m_Lens.OrthographicSize-0.1f, 20));
        }
    }
}
