using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestroyByContactSmall : MonoBehaviour
{
    private GameController gameController;
    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }
        if (other.tag == "Player")
        {
            gameController.GameOver();
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
        Score.scoreValue += 10;
    }
}
