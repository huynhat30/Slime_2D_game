using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSword : MonoBehaviour
{
    [SerializeField] private float SwordSpeed = 0.1f;
    void Update()
    {
        transform.Rotate(0, 0, 360 * SwordSpeed * Time.deltaTime);
    }
}
