/*using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class KeyPointVisibilityChecker : MonoBehaviour
{
    public Transform[] keyPoints; // Array of key points attached to the crane
    public Camera mainCamera; // Main camera in the scene
    public float scanInterval = 3f; // Interval for scanning the scene in seconds

    private List<int> visibilityList; // List to store visibility status of key points
    private StreamWriter writer;

    void Start()
    {
        visibilityList = new List<int>();
        writer = new StreamWriter(@"C:\Users\abdak\OneDrive\Skrivebord\Master Oppgaven\keypointVisibel.txt", false);
        InvokeRepeating("CheckVisibility", 0f, scanInterval); // Call CheckVisibility every scanInterval seconds
    }

    void OnDestroy()
    {
        if (writer != null)
        {
            writer.Close();
        }
    }

    void CheckVisibility()
    {
        visibilityList.Clear();

        foreach (Transform keyPoint in keyPoints)
        {
            // Perform raycast from camera to key point
            RaycastHit hit;
            Vector3 direction = (keyPoint.position - mainCamera.transform.position).normalized;
            Debug.DrawRay(mainCamera.transform.position, direction * 20f, Color.red, 3f); // Visualize raycast
            if (Physics.Raycast(mainCamera.transform.position, direction, out hit))
            {
                Debug.Log("Raycast hit: " + hit.collider.transform.name);
                if (hit.collider.transform == keyPoint)
                {
                    // Key point is visible from camera
                    visibilityList.Add(1);
                }
                else
                {
                    // Key point is not visible from camera
                    visibilityList.Add(0);
                }
            }
            else
            {
                Debug.Log("Raycast didn't hit anything.");
                // Key point is not visible from camera
                visibilityList.Add(0);
            }
        }

        // Print visibility list
        PrintVisibilityList();
    }


    void PrintVisibilityList()
    {
        string output = "Visibility List: \n";
        foreach (int visibility in visibilityList)
        {
            output += visibility + "\n";
        }
        Debug.Log(output);
        writer.Write(output);
    }
}

*/

using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class KeyPointVisibilityChecker : MonoBehaviour
{
    public Transform[] keyPoints; // Array of key points attached to the crane
    public Camera mainCamera; // Main camera in the scene
    public float scanInterval = 3f; // Interval for scanning the scene in seconds

    private List<string> visibilityList; // List to store visibility status and distances of key points
    private StreamWriter writer;

    void Start()
    {
        visibilityList = new List<string>();
        writer = new StreamWriter(@"C:\Users\abdak\OneDrive\Skrivebord\Master Oppgaven\keypointVisibel.txt", false);
        InvokeRepeating("CheckVisibility", 0f, scanInterval); // Call CheckVisibility every scanInterval seconds
    }

    void OnDestroy()
    {
        if (writer != null)
        {
            writer.Close();
        }
    }

    void CheckVisibility()
    {
        visibilityList.Clear();

        foreach (Transform keyPoint in keyPoints)
        {
            // Perform raycast from camera to key point
            RaycastHit hit;
            Vector3 direction = (keyPoint.position - mainCamera.transform.position);
            float distance = direction.magnitude; // Calculate distance from camera to key point
            direction.Normalize();
            Debug.DrawRay(mainCamera.transform.position, direction * 20f, Color.red, 3f); // Visualize raycast
            if (Physics.Raycast(mainCamera.transform.position, direction, out hit))
            {
                Debug.Log("Raycast hit: " + hit.collider.transform.name);
                if (hit.collider.transform == keyPoint)
                {
                    // Key point is visible from camera
                    visibilityList.Add("1," + distance); // Store visibility status and distance
                }
                else
                {
                    // Key point is not visible from camera
                    visibilityList.Add("0," + distance); // Store visibility status and distance
                }
            }
            else
            {
                Debug.Log("Raycast didn't hit anything.");
                // Key point is not visible from camera
                visibilityList.Add("0," + distance); // Store visibility status and distance
            }
        }

        // Print visibility list
        PrintVisibilityList();
    }


    void PrintVisibilityList()
    {
        string output = "Visibility List: \n";
        foreach (string entry in visibilityList)
        {
            output += entry + "\n";
        }
        Debug.Log(output);
        writer.Write(output);
    }
}
