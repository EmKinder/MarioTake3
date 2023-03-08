using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{


    // Start is called before the first frame update
    public GameObject rat;
    public Camera camera;
    void LateUpdate()
    {
        camera.transform.position = new Vector3 (rat.transform.position.x, 1.8f, transform.position.z);
    }
}
