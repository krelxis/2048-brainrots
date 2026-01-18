using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Cell : MonoBehaviour
{
    public int X;
    public int Y;

    public int Value;
    public int Points => IsEmpty ? 0 : (int)Mathf.Pow(2, Value);

    public bool IsEmpty => Value == 0;

    public bool HasMarged;

    public const int MaxValue = 11;

    [SerializeField]
    private Image _image;
    [SerializeField]
    private TextMeshProUGUI _points;

    private CellAnimation currentAnimation;

    [HideInInspector]
    public int LastValue;

    public void SetValue(int x, int y, int value, bool updateUI = true)
    {
        X = x;
        Y = y;
        Value = value;

        if(updateUI)
            UpdateCell();
    }

    public void IncreaseValue()
    {
        Value++;
        HasMarged = true;

        AudioController.Instance.CheckMaxIndex(Value);
        GameController.Instance.AddPoints(Points);
    }

    public void ResetFlags()
    {
        HasMarged = false;
    }

    public void MergeWithCell(Cell otherCell)
    {
        CellAnimationController.Instance.SmoothTransition(this, otherCell, true); 

        otherCell.IncreaseValue();
        SetValue(X, Y, 0);
    }

    public void MoveToCell(Cell target)
    {
        CellAnimationController.Instance.SmoothTransition(this, target, false);

        target.SetValue(target.X, target.Y, Value, false);
        SetValue(X, Y, 0);
    }

    public void UpdateCell()
    {
        _points.text = IsEmpty ? string.Empty : Points.ToString();

        /*_points.color = Value <= 2 ? ColorManager.Instance.DarkColor :
            ColorManager.Instance.LightColor;*/

        _image.color = ColorManager.Instance.CellCollors[Value];
        _image.sprite = ColorManager.Instance.CellSprite[Value];
    }

    public void SetAnimation(CellAnimation animation)
    {
        currentAnimation = animation;
    } 
    public void CancelAnimation()
    {
        if (currentAnimation != null)
            currentAnimation.Destroy();
    } 

    public void SaveValue()
    {
        LastValue = Value;
    }
}
