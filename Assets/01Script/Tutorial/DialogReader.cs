using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogLine
{
    public int No;
    public string Script;
}
public class DialogReader : MonoBehaviour
{
    [SerializeField] private TextAsset dialogFile;

    public List<DialogLine> LoadDialog()
    {
        string[] lines = dialogFile.text.Split("\n");
        List<DialogLine> dialogList = new List<DialogLine>();

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }
            string[] values = SpliteCSVLine(line);

            DialogLine dialog = new DialogLine
            {
                No = int.Parse(values[0]),
                Script = values[1]
            };

            dialogList.Add(dialog);
        }

        return dialogList;
    }
    private string[] SpliteCSVLine(string line)
    {
        List<string> result = new List<string>();
        bool isQuotes = false;
        string currentValue = "";

        foreach (char character in line)
        {
            if (character == '"')
            {
                isQuotes = !isQuotes;
                continue;
            }

            if (character == ',' && !isQuotes)
            {
                result.Add(currentValue);
                currentValue = "";
            }
            else
            {
                currentValue += character;
            }   
        }
        result.Add(currentValue);
        return result.ToArray();
    }
}
