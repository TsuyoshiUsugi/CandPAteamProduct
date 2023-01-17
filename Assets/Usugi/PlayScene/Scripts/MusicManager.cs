using UnityEngine;

public class MusicManager : MonoBehaviour
{
    AudioSource _audio;
    AudioClip _music;
    [SerializeField] string _songName;
    GameState _currentState;
    public GameState CurrentState => _currentState;

    // Start is called before the first frame update
    void Start()
    {
        _audio = GetComponent<AudioSource>();
        _music = Resources.Load("Music/" + _songName) as AudioClip;
        _audio.clip = _music;
        _currentState = GameState.Ready;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && _currentState == GameState.Ready)
        {
            PlaySceneManager.instance.Start = true;
            PlaySceneManager.instance.StartTime = Time.time;

            _currentState = GameState.Playing;
            _audio.Play();
        }

    }

    public enum GameState
    {
        Playing,
        Ready,
    }
}
