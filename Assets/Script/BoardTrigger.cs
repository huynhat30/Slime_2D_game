using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardTrigger : MonoBehaviour
{
    [SerializeField] private Text instruction;
    // Start is called before the first frame update
    void Start()
    {
        instruction.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Slime")) {
            instruction.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Slime"))
        {
            instruction.enabled = false;
        }
    }
}
