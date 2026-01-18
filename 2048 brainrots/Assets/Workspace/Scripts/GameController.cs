using UnityEngine;
using UnityEngine.Events; 
using TMPro;
using YG;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public static int Points;
    public static int Record;
    public static bool GameStarted;

    [SerializeField]
    private ResultPanel _gameResult;
    [SerializeField]
    private TextMeshProUGUI _pointsText;
    [SerializeField]
    private TextMeshProUGUI _recordText;

    [SerializeField]
    private UnityEvent OnWinEvents;
    [SerializeField]
    private UnityEvent OnLooseEvents;


    public void AddPoints(int points)
    {
        SetPoints(Points + points);

        if (Points > Record)
            SetRecord(Points);
    } 

    public void SetPoints(int points)
    {
        Points = points;
        _pointsText.text = points.ToString();
    }

    public void SetRecord(int newRecord)
    {
        Record = newRecord;
        _recordText.text = newRecord.ToString();
        YG2.saves.record = newRecord;

        YG2.SaveProgress();

    }

    public void Win()
    {
        GameStarted = false;
        OnWinEvents.Invoke();
        _gameResult.gameObject.SetActive(true);
        _gameResult.Light();
        YG2.SetLeaderboard("LeaderboardYG2", Record);
    }

    public void Lose()
    {
        GameStarted = false;
        OnLooseEvents.Invoke();
        _gameResult.gameObject.SetActive(true);
        _gameResult.Light();
        YG2.SetLeaderboard("LeaderboardYG2", Record);
    }

    public void StartGame()
    {
        _gameResult.InstaShade();

        SetPoints(0);
        GameStarted = true;

        Field.Instance.GenerateField();
    }

    public void ShowAD()
    {
        YG2.InterstitialAdvShow();
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        StartGame();
        SetRecord(YG2.saves.record);
    }
}
