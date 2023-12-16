using UnityEngine;

public class OptionsPanelController : MonoBehaviour
{
    public GameObject optionsPanel; // Assign the options panel GameObject in the inspector

    // Update is called once per frame
    void Update()
    {
        // Check if the Tab key was pressed
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // Toggle the visibility of the options panel
            optionsPanel.SetActive(!optionsPanel.activeSelf);
        }
    }
}
