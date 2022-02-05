using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinamachinePOVExtension : CinemachineExtension
{
    private float clampAngle = 80f;
    private float horizontalSensitivity = 10f;
    private float verticalSensitivity = 10f;
    private BetterInputManager inputManager;
    private Vector3 startingRotation;

    protected override void Awake()
    {
        inputManager = BetterInputManager.Instance;
        base.Awake();
    }

    //overriding the PostPipelineStageCallback method so we can get new input system to work with cinemachine
    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam,CinemachineCore.Stage stage,ref CameraState state,float deltaTime){
        if(vcam.Follow)
        {
            //if we are in the aiming stage we want to aim.
            if(stage == CinemachineCore.Stage.Aim)
            {
                if(startingRotation == null) startingRotation = transform.localRotation.eulerAngles;
                
                Vector2 deltaInput = inputManager.GetMouseDelta();
                
                startingRotation.x += deltaInput.x * horizontalSensitivity * Time.deltaTime;
                startingRotation.y += deltaInput.y * verticalSensitivity * Time.deltaTime;

                startingRotation.y = Mathf.Clamp(startingRotation.y, -clampAngle, clampAngle);
                //startingRotation.x = Mathf.Clamp(startingRotation.x, -clampAngle, clampAngle);

                state.RawOrientation = Quaternion.Euler(-startingRotation.y, startingRotation.x, 0f);

            }
        }
    }
  
}
