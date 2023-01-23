using UnityEngine;

/// <summary>
/// ƒXƒRƒAî•ñ‚ğ•Û‚·‚é
/// </summary>
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance = null;

    public int combo;
    public int score;

    public int perfect;
    public int great;
    public int bad;
    public int miss;

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
