using UnityEngine;
[System.Serializable]
public class Dialog
{
    public string title;
    [TextArea(3, 10)]
    public string[] messages;
}
