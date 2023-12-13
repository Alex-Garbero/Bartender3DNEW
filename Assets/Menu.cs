using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    private string [] drinks;
    
    // Start is called before the first frame update
    void Start()
    {
        string fileName = "Drinks.csv";
        // Load the CSV file as a TextAsset
        TextAsset csvFile = Resources.Load<TextAsset>(fileName);

        // Check if the file is found
        if (csvFile == null)
        {
            Debug.LogError($"CSV file '{fileName}' not found in Resources folder.");
            return;
        }

        // Parse the CSV file
        string[] lines = csvFile.text.Split('\n');

        // Create a list to store arrays of strings
        List<string[]> data = new List<string[]>();

        // Read each line and split it into an array of strings
        foreach (string line in lines)
        {
            string[] values = line.Trim().Split(',');
            data.Add(values);
        }

        // Convert list to array if needed
        string[][] dataArray = data.ToArray();

        // Now, 'dataArray' contains your CSV data as an array of strings
        foreach (var row in dataArray)
        {
            foreach (var column in row)
            {
                Debug.Log(column);
            }
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
