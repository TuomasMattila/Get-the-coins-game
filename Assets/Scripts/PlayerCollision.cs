using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            FindObjectOfType<GameManager>().CoinCollected();
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Enemy"))
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioListener>().enabled = true;
            Destroy(gameObject);
            FindObjectOfType<GameManager>().EndGame(false);
        }
    }

}
