using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform Target;
    public GameObject Canvas;
    void LateUpdate()
    {
        Canvas.transform.LookAt(Canvas.transform.position + Target.forward);
    }
}
