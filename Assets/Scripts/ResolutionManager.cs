using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResolutionManager : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolutionDropdown; // Dropdown UI element to display resolution options

    private Resolution[] resolutions; // Array to hold all possible screen resolutions
    private List<Resolution> filteredResolutions; // List to hold filtered resolutions based on refresh rate
    private float currentRefreshRate; // To store the current refresh rate of the screen
    private int currentResolutionIndex = 0; // To keep track of the current resolution index

    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions; // Get all available screen resolutions
        filteredResolutions = new List<Resolution>();

        resolutionDropdown.ClearOptions(); // Clear existing options in the dropdown
        currentRefreshRate = Screen.currentResolution.refreshRate; // Get the current screen refresh rate

        // Loop through all resolutions and add resolutions matching the current refresh rate to filteredResolutions
        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].refreshRate == currentRefreshRate)
            {
                filteredResolutions.Add(resolutions[i]);
            }
        }

        // Create a list of strings to represent the resolution options in the dropdown
        List<string> options = new List<string>();
        for (int i = 0; i < filteredResolutions.Count; i++)
        {
            // Format the resolution option as "width x height refreshRateHz"
            string resolutionOption = filteredResolutions[i].width + "x" + filteredResolutions[i].height + " " + filteredResolutions[i].refreshRate + "Hz";
            options.Add(resolutionOption);

            // If this resolution matches the current screen resolution, set it as the current resolution index
            if (filteredResolutions[i].width == Screen.width && filteredResolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        // Add the resolution options to the dropdown and set the currently selected option
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue(); // Refresh the dropdown to show the current selection
    }

    // Update method is not used in this script
    void Update()
    {

    }

    // Method to set the screen resolution based on the selected option in the dropdown
    public void SetResolution(int resolutionIndex)
    {
        // Get the resolution from filteredResolutions based on the selected index
        Resolution resolution = filteredResolutions[resolutionIndex];
        // Set the screen resolution and apply it immediately
        Screen.SetResolution(resolution.width, resolution.height, true);
    }
}
