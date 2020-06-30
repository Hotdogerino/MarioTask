using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Text _scoreCoinText;
    [SerializeField]
    private Text _levelText;
    [SerializeField]
    private Text _timeText;
    public static int score = 0;
    private ScoreManager _scoreManager;
    private int level;
    // Start is called before the first frame update
    void Start()
    {
        _scoreManager = GameObject.Find("ScoreManagerObj").GetComponent<ScoreManager>();
        level = SceneManager.GetActiveScene().buildIndex + 1;
    }

    // Update is called once per frame
    void Update()
    {
        _scoreText.text = "" + _scoreManager.GetScore();
        _scoreCoinText.text = "x" + _scoreManager.GetCoins();
        _levelText.text = "1-" + level;
        if (_scoreManager.GetCurrentTime() >= 0)
        {
            _timeText.text = "" + _scoreManager.GetCurrentTime();
        }
        else
            _timeText.text = "0";
    }
}
