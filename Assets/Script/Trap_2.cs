using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Trap_2 : MonoBehaviour
{
    private Vector2 originalPosition;
    public AnimationCurve curve;
    // Start is called before the first frame update
    private void Start()
    {
        originalPosition = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = new Vector2(curve.Evaluate(Time.time) + originalPosition.x, originalPosition.y);
    }

}