using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[RequireComponent(typeof(Camera))]

public class snapshotCamerR : MonoBehaviour
{
    Camera snapCam;
    int resWidth = 1920;
    int resHeight = 1080;

    // Specify the directory path where the images should be saved
    string saveDirectory = @"C:\Users\abdak\OneDrive\Skrivebord\Master Oppgaven\DataSet\right_images";

    void Awake()
    {
        snapCam = GetComponent<Camera>();
        if (snapCam.targetTexture == null)
        {
            snapCam.targetTexture = new RenderTexture(resWidth, resHeight, 48);
        }
        else
        {
            resWidth = snapCam.targetTexture.width;
            resHeight = snapCam.targetTexture.height;
        }

        snapCam.gameObject.SetActive(false);
    }

    public void CallTakeSnapshot()
    {
        snapCam.gameObject.SetActive(true);
    }

    void LateUpdate()
    {
        if (snapCam.gameObject.activeInHierarchy)
        {
            Texture2D snapshot = new Texture2D(resWidth, resHeight, TextureFormat.RGB48, false);
            snapCam.Render();
            RenderTexture.active = snapCam.targetTexture;
            snapshot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
            byte[] bytes = snapshot.EncodeToPNG();
            string filename = SnapshotName();
            System.IO.File.WriteAllBytes(filename, bytes);
            Debug.Log("Snapshot R taken!");
            snapCam.gameObject.SetActive(false);
        }
    }

    int snapshotCount = 0;

    string SnapshotName()
    {
        string fileName = string.Format("imgr{0}.png", snapshotCount);
        snapshotCount++;
        return Path.Combine(saveDirectory, fileName);
    }
}




