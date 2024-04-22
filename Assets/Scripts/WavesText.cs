using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WavesText : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = SpawnManager.GetWaveNumber().ToString();
    }
}
