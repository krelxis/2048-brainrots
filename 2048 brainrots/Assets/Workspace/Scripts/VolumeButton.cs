using UnityEngine;
using UnityEngine.UI;
using PlayerPrefs = RedefineYG.PlayerPrefs;

[RequireComponent(typeof(Image))]
public class VolumeButton : MonoBehaviour
{
    [SerializeField]
    private string _volumeName;

    [Header("Sprites")]
    [SerializeField]
    private Color _activeColor;
    [SerializeField]
    private Color _disableColor;

    [Header("GameObjects")]
    [SerializeField]
    private GameObject _activeObj;
    [SerializeField]
    private GameObject _unactiveObj;

    private Image _img;

    [SerializeField]
    private bool _isActive; 

    public void OnClick()
    {
        if(_isActive == true)
        {
            DisableButton();
            return;
        } 
        if(_isActive == false)
        {
            ActivateButton();
            return;
        }
    } 

    private void ActivateButton()
    {
        Options.Instance.SetVolumeState(true, _volumeName);
        _isActive = true;

        _img.color = _activeColor;

        if (_unactiveObj != null && _activeObj != null)
        {
            _unactiveObj.gameObject.SetActive(false);
            _activeObj.gameObject.SetActive(true);
        }
    }
    private void DisableButton()
    {
        Options.Instance.SetVolumeState(false, _volumeName);
        _isActive = false;

        _img.color = _disableColor;

        if (_unactiveObj != null && _activeObj != null) {
            _unactiveObj.gameObject.SetActive(true);
            _activeObj.gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        _img = GetComponent<Image>();
        //PlayerPrefs.DeleteAll();
        Init();
    } 

    private void Init()
    {
        int isActive = PlayerPrefs.GetInt(_volumeName);

        if (isActive == 1 || isActive == 0)
            ActivateButton();
        if (isActive == 2)
            DisableButton();
    }
}
