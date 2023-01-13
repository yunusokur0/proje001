using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounds : MonoBehaviour
{
    [SerializeField] private Transform vectorback;
    [SerializeField] private Transform vectorforward;

    private void LateUpdate()   
    {
        Vector3 viewPos = transform.position;

        viewPos.z = Mathf.Clamp(viewPos.z, vectorback.transform.position.z, vectorforward.transform.position.z);
        viewPos.x = Mathf.Clamp(viewPos.x,-4.30f,4.35f );
        transform.position = viewPos;


    }
}
