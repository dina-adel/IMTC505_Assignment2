using UnityEngine;
using UnityEngine.UI;
using TMPro; 

/*
    This script works on switching from day to night using a button in the scene. 
    For day, I am using the default skybox. For night, I used an asset from the store, StarSkybox. 
    Simply, the script is checking the "onClick" event in the button and switching based on that.
*/

public class ToggleSkybox : MonoBehaviour
{
    public Material nightSkybox; // To store the night skybox
    public Material defaultSkybox; // To store the default skybox
    public Button toggleButton; // Reference to the button
    public TMP_Text buttonText; // Reference to the TextMeshPro component of the button

    void Start()
    {
        toggleButton.onClick.AddListener(ToggleDayNight);
    }

    void ToggleDayNight()
    {
        Debug.Log("Button Clicked!"); 
        if (RenderSettings.skybox == defaultSkybox)
        {
            RenderSettings.skybox = nightSkybox; 
            buttonText.text = "Day";
        }
        else
        {
            RenderSettings.skybox = defaultSkybox;
            buttonText.text = "Night";
        }
       
        toggleButton.OnDeselect(null);  // To reset to normal state
    }
}
