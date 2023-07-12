using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]private Transform slime;

    // Update is called once per frame
    private void Update()
    {
        transform.position = new Vector3(slime.position.x, slime.position.y,transform.position.z);
    }
}
