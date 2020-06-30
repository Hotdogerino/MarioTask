using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    public static int score = 0;
    private ScoreManager _scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        _scoreManager = GameObject.Find("ScoreManagerObj").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        _scoreText.text = "" + _scoreManager.GetScore();
    }
}
