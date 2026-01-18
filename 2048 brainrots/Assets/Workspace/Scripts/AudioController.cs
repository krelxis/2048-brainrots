using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance;

    [SerializeField] private AudioSource[] _audioObjects;

    private int _indexAudio = 0;

    private bool _delay;
    [SerializeField] private float _delayTimer;
    private float _delayTime;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Update()
    {
        if (_delay == false) { return; }

        _delayTime += Time.deltaTime;

        if(_delayTime >= _delayTimer)
        {
            _audioObjects[_indexAudio].Play();
            _delayTime = 0;
            _indexAudio = 0;
            _delay = false;
        }
    }

    public void CheckMaxIndex(int newIndex)
    {
        if (_indexAudio >= newIndex) { return; }

        _delay = true;
        _indexAudio = newIndex;
    }
}
