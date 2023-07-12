using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenWay : MonoBehaviour
{
    [SerializeField] private BoxCollider2D SomeThingHere;
    [SerializeField] private BoxCollider2D ThatTheTrigger;
    [SerializeField] private Text pressE;
    private bool touch;
    // Start is called before the first frame update
    void Start()
    {
        ThatTheTrigger = GetComponent<BoxCollider2D>();
        pressE.enabled = false;
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Slime")) {
            pressE.enabled = true;
            touch = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && touch == true)
        {
            ThatTheTrigger.isTrigger = true;
            SomeThingHere.isTrigger = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Slime"))
        {
            pressE.enabled = false;
            ThatTheTrigger.isTrigger = false;  
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Slime"))
        {
            pressE.enabled = false;
        }
    }
}
