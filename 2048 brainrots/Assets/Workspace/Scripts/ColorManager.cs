using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public static ColorManager Instance;

    public Color[] CellCollors;
    public Sprite[] CellSprite;

    [Space(5)]
    public Color DarkColor;
    public Color LightColor;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
}
