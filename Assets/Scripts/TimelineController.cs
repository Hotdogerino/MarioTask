using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TimelineController : MonoBehaviour
{
    [SerializeField]
    private PlayableDirector playableDirector;
    private float yAxis;
    [SerializeField]
    private GameObject _flag;
    [SerializeField]
    private PlayableDirector playableDirectorSmall;
    private PlayerController _playerController;
    [SerializeField]
    private GameObject PlayerGameObject;
    [SerializeField]
    private PlayableDirector playableDirectorFireworks;
    [SerializeField]
    private GameObject _audioControl;
    private AudioManager _audioManager;
    private bool _hasEnteredCastle = false;
    //[SerializeField]
    //private GameObject _fireworks;
    [SerializeField]
    private GameObject _fireworkContainer;
    private bool _stopSpawning = false;
    [SerializeField]
    private GameObject[] _fireworks;


    // Start is called before the first frame update
    void Start()
    {
        _playerController = PlayerGameObject.GetComponent<PlayerController>();
        _audioManager = _audioControl.GetComponent<AudioManager>();


    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PlayBig()
    {
        playableDirector.Play();

    }
    public void PlaySmall()
    {
        playableDirectorSmall.Play();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            if (_hasEnteredCastle == false)
            {
                _audioManager.PlayFlagAudio();
            }
            var yAxis = collision.GetContact(0).point.y; // global
            var yaxisOfFlag = collision.otherCollider.bounds.size.y;
            float something = 0;
            if (yAxis < 0)
            {
                something = -yAxis / yaxisOfFlag;//9.5f; hardcoded // make the yaxis - so that i could get the positive yaxis
            }
            else if (yAxis > 0)
            {
                something = (yAxis + 2) / yaxisOfFlag;//9.5f; hardcoded // add the 2 from the negative axis
            }
            playableDirector.initialTime = 2.3 - something * 2.3;
            playableDirectorSmall.initialTime = 2.3 - something * 2.3;
            if (_playerController.poweredUp)
            {
                PlayBig();
            }
            if (!_playerController.poweredUp)
            {
                PlaySmall();
            }
            StartCoroutine(MarioGoesToCastle());
            if (_hasEnteredCastle == true)
            {
                playableDirector.Stop();
                playableDirectorSmall.Stop();
                PlayerGameObject.SetActive(false);

            }
            //StartCoroutine(WaitForFireworks());
            //Debug.Log(something);
            //playableDirector.GetComponent<Animation>().gameObject.transform.position = new Vector3(_player.transform.position.x, yAxis, _player.transform.position.z);

        }
    }
    private IEnumerator MarioGoesToCastle()
    {

        if (_hasEnteredCastle == false)
        {
            yield return new WaitForSeconds(3.5f);
            PlayerGameObject.GetComponent<SpriteRenderer>().enabled = false;
            _audioManager.PlayWinAudio();
            //StartCoroutine(FireworksExplode());
            _hasEnteredCastle = true;
        }
        StopCoroutine(MarioGoesToCastle());
    }
    //private IEnumerator FireworksExplode()
    //{
    //    _fireworks[0].SetActive(true);
    //    yield return new WaitForSeconds(1);
    //    _fireworks[0].SetActive(false);
    //    _fireworks[1].SetActive(true);
    //    yield return new WaitForSeconds(1);
    //    _fireworks[1].SetActive(false);
    //    _fireworks[2].SetActive(true);
    //    yield return new WaitForSeconds(1);
    //    _fireworks[2].SetActive(false);
    //    _fireworks[3].SetActive(true);
    //    yield return new WaitForSeconds(1);
    //    _fireworks[3].SetActive(false);
    //    StopCoroutine(FireworksExplode());
    //}
    //void InstantiatesFirework()
    //{
    //    GameObject fireworks = Instantiate(_fireworks, new Vector3(Random.Range(120f, 130f), Random.Range(3f, 7f), transform.position.z), Quaternion.identity);
    //    fireworks.transform.parent = _fireworkContainer.transform;
    //    Destroy(fireworks, 2);
    //}
    //IEnumerator WaitForFireworks()
    //{
    //    while (_stopSpawning == false)
    //    {
    //        yield return new WaitForSeconds(1);
    //        InstantiatesFirework();

    //    }
    //}
}