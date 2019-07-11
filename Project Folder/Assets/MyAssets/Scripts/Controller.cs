using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    GameManager gameManager;
    ButtonManager buttonManager;
    void Awake()
    {
        buttonManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ButtonManager>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    void Start()
    {
        buttonManager.material = GameObject.FindGameObjectWithTag("BoxToDeliver").GetComponent<Renderer>().material;
        buttonManager.BoxToDeliver = gameObject;
        // -Variables
    }
    bool isQuitting = false;
    void OnApplicationQuit()
    {
        isQuitting = true;
    }
    void OnDestroy()
    {
        if (!isQuitting)
        Instantiate(gameManager.cubePrefab, gameManager.cubePrefab.transform.position, gameManager.cubePrefab.transform.rotation);
    }
}