using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerranceAppear : MonoBehaviour
{

    [SerializeField]private BoxCollider2D TeranceAppear;
    // Start is called before the first frame update
    void Start()
    {
        TeranceAppear.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Slime"))
        {
            TeranceAppear.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Slime"))
        {
            TeranceAppear.enabled = true;
        }
    }
}
