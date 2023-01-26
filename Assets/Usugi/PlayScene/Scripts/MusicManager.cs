using UnityEngine;
using UniRx;

public class MusicManager : SingletonMonobehavior<MusicManager>
{
    AudioSource _audio;
    AudioClip _music;

    [SerializeField] ReactiveProperty<GameState> _currentState;
    public ReactiveProperty<GameState> CurrentState { get => _currentState; set => _currentState = value; }

    float _startTime;
    public float StartTime => _startTime;

    // Start is called before the first frame update
    void Start()
    {
        _audio = GetComponent<AudioSource>();
        _music = Resources.Load("Music/" + SongInfoManager.Instance.SongPath) as AudioClip;
        _audio.clip = _music;
        _currentState.Value = GameState.Ready;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && _currentState.Value == GameState.Ready)
        {
            _startTime = Time.time;

            _currentState.Value = GameState.Playing;
            _audio.Play();
        }

    }

    public enum GameState
    {
        Playing,
        Ready,
        End,
    }
}
