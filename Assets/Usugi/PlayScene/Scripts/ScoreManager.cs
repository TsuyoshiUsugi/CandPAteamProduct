using UnityEngine;

/// <summary>
/// ƒXƒRƒAî•ñ‚ğ•Û‚·‚é
/// </summary>
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance = null;

    public int _combo;
    public int _score;

    public int _perfect;
    public int _great;
    public int _bad;
    public int _miss;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
