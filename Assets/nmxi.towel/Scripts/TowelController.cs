using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using VRM;

public class TowelController : MonoBehaviour
{
    [SerializeField] private GameObject referenceHand;
    [SerializeField] private VRMSpringBone vRMSpringBone;

    [Space(15f), SerializeField] private GameObject towelBone1;

    [SerializeField] private float thresold;

    [Space(15f), SerializeField] private float lowStiffnessForce;
    [SerializeField] private float highStiffnessForce;
    [SerializeField] float lowDragForce;
    [SerializeField] float highDragForce;

    private VelocityEstimator velocityEstimator;

    private void Awake()
    {
        velocityEstimator = referenceHand.GetComponent<VelocityEstimator>();
    }

    void Update()
    {
        if (velocityEstimator == null)
            return;

        towelBone1.transform.position = referenceHand.transform.position;

        var acc = velocityEstimator.GetAccelerationEstimate();
        var accAvr = Mathf.Abs((acc.x + acc.y + acc.z) / 3f);

        //Debug.Log(accAvr);

        if(accAvr < thresold)
        {
            vRMSpringBone.m_stiffnessForce = lowStiffnessForce;
            vRMSpringBone.m_dragForce = lowDragForce;
        }
        else
        {
            vRMSpringBone.m_stiffnessForce = highStiffnessForce;
            vRMSpringBone.m_dragForce = highDragForce;
        }
    }
}
