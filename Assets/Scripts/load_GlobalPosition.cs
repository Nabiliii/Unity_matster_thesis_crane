using UnityEngine;
using System.IO;

public class LoadGlobalPosition : MonoBehaviour
{
    public Transform load; // Assign the load's transform in the Inspector
    private string logFileName = "C:\\Users\\abdak\\OneDrive\\Skrivebord\\Master Oppgaven\\DataSet\\annotations\\ROV_Pose.txt";
    private int currentIndex = 0; // Initialize the index
    private float captureInterval = 3f; // Set the interval in seconds

    void Start()
    {
        // Create or open the log file for writing
        using (StreamWriter writer = new StreamWriter(logFileName, false))
        {
            // Write the names of the elements in the first line
            writer.WriteLine(" x ; y ; z ; pith ; yaw ; roll ");
            writer.WriteLine("");
        }

        // Start invoking the CapturePosition method every captureInterval seconds
        InvokeRepeating("CapturePosition", 0f, captureInterval);
    }

    void CapturePosition()
    {
        // Check if the load transform is assigned
        if (load != null)
        {
            // Get the global (world) position of the load
            Vector3 globalPosition = load.position;

            // Convert the position to millimeters
            globalPosition *= 1000.0f;

            // Subtract 1130 mm from the Y position
            globalPosition.y -= 1130.0f;

            // Get the global (world) rotation of the load
            Quaternion globalRotation = load.rotation;

            // Create or open the log file for writing
            using (StreamWriter writer = new StreamWriter(logFileName, true))
            {
                // Write the global position and rotation with an index
                string logMessage = string.Format("{0:F2}; {1:F2}; {2:F2}; {3:F2}; {4:F2}; {5:F2}",
                    globalPosition.x, globalPosition.y, globalPosition.z,
                    globalRotation.eulerAngles.x, globalRotation.eulerAngles.y, globalRotation.eulerAngles.z);
                writer.WriteLine(logMessage);

                // Increment the index for the next line
                currentIndex++;
            }
        }
        else
        {
            Debug.LogError("Load transform is not assigned.");
        }
    }
}
