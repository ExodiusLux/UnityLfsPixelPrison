using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TBManager : MonoBehaviour
{
    public GameObject textBox;
    public Text dialogue;
    public TextAsset textFile;
    public string[] textLines;
    public int currentLine;
    public int endAtLine;
    public bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }

        if(endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }

        if (isActive)
        {
            textBox.SetActive(true);
        }
        else
        {
            textBox.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        dialogue.text = textLines[currentLine];

        if (Input.GetKeyDown(KeyCode.E) && currentLine < endAtLine)
        {
            currentLine += 1;
        }

        if (Input.GetKeyDown(KeyCode.Q) && currentLine != 0)
        {
            currentLine -= 1;
        }

        if(Input.GetKeyDown(KeyCode.Tab) && isActive)
        {
            textBox.SetActive(false);
        }

        

    }
}
