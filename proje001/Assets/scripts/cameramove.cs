using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramove : MonoBehaviour
{
    public int forwartspeedi;

    void Update()
    {
        if (variable.firsttouch == 1)
        {
            transform.position += new Vector3(0, 0, forwartspeedi * Time.deltaTime);
        }
    }
}
