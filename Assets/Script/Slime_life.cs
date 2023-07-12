using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Slime_life : MonoBehaviour
{
    private Animator a;
    private Rigidbody2D r;

    [SerializeField] private AudioSource DeathSound;
    // Start is called before the first frame update
    void Start()
    {
        a = GetComponent<Animator>();
        r = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap") )
        {
            Death();
        }

        if (collision.gameObject.CompareTag("BallTrap"))
        {
            Death();
        }
    }

    private void Death() {
        DeathSound.Play();
        r.bodyType = RigidbodyType2D.Static;
        a.SetTrigger("Death");
        Debug.Log("Slime death");
    }

    private void BackAgin() {
        r.bodyType = RigidbodyType2D.Dynamic;
    }

    private void RestartLvl() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
