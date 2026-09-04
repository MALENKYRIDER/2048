using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TileVisual : MonoBehaviour
{
    [SerializeField] private TMP_Text _tileNumberText;
    [SerializeField] private Image _tileBackground;
    [SerializeField] private Image _tileBackgroundShadow;
    [SerializeField] private TileColorPalette _tileColorPalette;

    public void SetupTile(int value)
    {
        _tileNumberText.text = value.ToString();
        Color backgroundColor = _tileColorPalette.GetColor(value);
        _tileBackground.color = backgroundColor;
        _tileBackgroundShadow.color = backgroundColor;
        _tileNumberText.color = SetupNumberColor(backgroundColor);
    }

    private Color SetupNumberColor(Color backgroundColor)
    {
        float brightness = backgroundColor.r * 0.3f + backgroundColor.g * 0.6f + backgroundColor.b * 0.1f;

        if (brightness >= 0.5f)
            return Color.black;
        else
            return Color.white;
    }
}