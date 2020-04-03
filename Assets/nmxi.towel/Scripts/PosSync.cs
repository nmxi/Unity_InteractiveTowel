using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosSync : MonoBehaviour
{
    [SerializeField] private Transform referenceTransform;

    void Update()
    {
        gameObject.transform.position = referenceTransform.position;
    }
}
