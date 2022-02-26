using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ChangeOrthosize : MonoBehaviour
{
    float PlayerMagnitude;
    public CinemachineVirtualCamera vcam;

    void Start(){
        vcam.m_Lens.OrthographicSize = 12;
    }    
    void FixedUpdate(){
        if (!Input.GetMouseButton(0)){
            PlayerMagnitude = ShootToMouse.PlayerVelocity.magnitude;
            if(PlayerMagnitude > 12){
                vcam.m_Lens.OrthographicSize = Mathf.Max(8, Mathf.Min(vcam.m_Lens.OrthographicSize+0.2f, 16));
            }
            else{
                vcam.m_Lens.OrthographicSize = Mathf.Max(8, Mathf.Min(vcam.m_Lens.OrthographicSize-0.1f, 16));
            }
        }
    }
}
