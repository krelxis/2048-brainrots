using UnityEngine;
using UnityEngine.Audio;
using PlayerPrefs = RedefineYG.PlayerPrefs;
using YG;

public class Options : MonoBehaviour
{
    public static Options Instance;

    public AudioMixer am; 

    public void SetVolumeState(bool state, string name)
    {
        if(state == true)
        {
            am.SetFloat(name, 0);
            PlayerPrefs.SetInt(name, 1);
            PlayerPrefs.Save();
            return;
        } 
        if(state == false)
        {
            am.SetFloat(name, -80);
            PlayerPrefs.SetInt(name, 2);
            PlayerPrefs.Save();
            return;
        }
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        int sfxState = 1;
        int musicState = 1;

        print(PlayerPrefs.GetInt("sfx"));

        //PlayerPrefs.DeleteAll();

        if (PlayerPrefs.HasKey("sfx")) { sfxState = PlayerPrefs.GetInt("sfx"); }
        else { sfxState = 1; }

        if (PlayerPrefs.HasKey("music")) { musicState = PlayerPrefs.GetInt("music"); }
        else { musicState = 1; }

        if (sfxState == 1 || sfxState == 0)
            am.SetFloat("sfx", 0);
        if (sfxState == 2)
            am.SetFloat("sfx", -80);
    }
}
