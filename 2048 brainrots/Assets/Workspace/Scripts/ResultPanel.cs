using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class ResultPanel : MonoBehaviour
{
    [SerializeField] private float _alphaBG;
    [SerializeField] private float _alpha;
    [SerializeField] private float _fadeTime;

    [SerializeField] private Image _bg;
    [SerializeField] private TextMeshProUGUI _resultText;
    [SerializeField] private Image _btn;
    [SerializeField] private TextMeshProUGUI _textBtnLoose;
    [SerializeField] private TextMeshProUGUI _textBtnWin;

    public void Light()
    {
        _bg.DOFade(_alphaBG, _fadeTime);
        _resultText.DOFade(_alpha, _fadeTime);
        _btn.DOFade(_alpha, _fadeTime);
        _textBtnLoose.DOFade(_alpha, _fadeTime);
        _textBtnWin.DOFade(_alpha, _fadeTime);
    }

    public void InstaShade()
    {
        _bg.DOFade(0, 0);
        _resultText.DOFade(0, 0);
        _btn.DOFade(0, 0);
        _textBtnLoose.DOFade(0, 0);
        _textBtnWin.DOFade(0, 0);
        gameObject.SetActive(false);
    }
}
