
using UnityEngine;

[System.Serializable]

public class Talk
{
    public string name = "阿钱";
    public GameObject CharacterImage;
    public GameObject NextText;
    public GameObject Choose;
    public GameObject BlackgroundImage;
    public int TextSize = 26;
    [TextArea(3,10)]
    public string[] sentences;
}
