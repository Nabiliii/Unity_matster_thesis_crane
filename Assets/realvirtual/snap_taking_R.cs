using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snap_taking_R : MonoBehaviour
{
    public snapshotCamerR snapCam;
    //public Drive info_saver;

    void Start()
    {
        // Start the snapshot process with a delay of 0 seconds and repeat every 3 seconds
        InvokeRepeating("TakeSnapshot", 0.3f, 3f);
    }

    void TakeSnapshot()
    {
        snapCam.CallTakeSnapshot();
        //info_saver.saveinfo();
    }
}
