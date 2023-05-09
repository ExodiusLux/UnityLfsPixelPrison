using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScreenScript : MonoBehaviour
{
    public GameObject tBox;
    public Text title;
    public Text subtitle;
    public Color Color1;
    public Color Color2;
    public bool tsActive;
    // Start is called before the first frame update
    void Start()
    {
        if (tsActive)
        {
            tBox.SetActive(true);
        }
        else
        {
            tBox.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        FlashingText();
        if (Input.GetKeyDown(KeyCode.Return) && tsActive)
        {
            tBox.SetActive(false);
        }
    }

    public void FlashingText()
    {
        subtitle.color = Color.Lerp(Color1, Color2, Mathf.PingPong(Time.time,1));
    }
}
