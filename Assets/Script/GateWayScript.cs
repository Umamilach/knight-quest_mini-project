using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GateWayScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        print("Masuk gerbang");
        // Masuk scene baru saat melewati objek ber-tag "Door"
        if (col.tag == "Player")
        {
            MoveScene("Level2");
        }
    }


    [SerializeField]
    private void MoveScene(string pageName)
    {
        SceneManager.LoadScene(pageName);
    }
}
