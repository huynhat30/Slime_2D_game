using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollect : MonoBehaviour
{
    private int pointInt;
    private int TotalCollective;

    [SerializeField] private Text point;
    [SerializeField] private Text TotalCollectTrue;
    [SerializeField] private Text TotalCollectFalse;
    [SerializeField] private AudioSource CollectSound;
    [SerializeField] private LevelController setPoint;
    // Start is called before the first frame update
    void Start()
    {
        TotalCollective = GameObject.FindGameObjectsWithTag("Collectives").Length * 10;
        setPoint.setTotalPoint(TotalCollective);
    }

    // Update is called once per frame
    void Update()
    {
        TotalCollectTrue.text = "Your score: " + pointInt + "/" + TotalCollective;
        TotalCollectFalse.text = "Your score: " + pointInt + "/" + TotalCollective;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Collectives")) {
            pointInt += 10;
            setPoint.setActualPoint(pointInt);
            Debug.Log("Point: " + pointInt);
            point.text = "Point:" + pointInt;
            CollectSound.Play();
            Destroy(collision.gameObject);
        }
    }
    
}
