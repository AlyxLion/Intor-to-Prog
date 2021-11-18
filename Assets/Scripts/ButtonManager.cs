using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonManager : MonoBehaviour
{
    public static int nukesLaunched;
    [SerializeField]
    Text nukesUICounter;
    Text workerUICounter;

    // Start is called before the first frame update
    void Start()
    {
        nukesLaunched = PlayerPrefs.GetInt("nukes", 0);
        UpdateText();
    }

    public void BigButtonPress()
    {
        nukesLaunched += 1;
        Debug.Log(nukesLaunched+"Button Pressed");
        
        UpdateText();

        PlayerPrefs.SetInt("nukes", nukesLaunched);
    }
    void UpdateText()
    {
        if (nukesLaunched != 1)
        {
            nukesUICounter.text = nukesLaunched + "Nukes";
        }
        else
        {
            nukesUICounter.text = nukesLaunched + "Nuke";
        }
    }
}
