using UnityEngine;

public class cameraScript : MonoBehaviour {

   
    public GameObject prefabobj;
    public float valy,valx;
    private void Start()
    {
        Instantiate(prefabobj);
    }
    private void Update()
    {
        prefabobj.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(valx, Screen.height - valy, Camera.main.farClipPlane / 2));
    }

}
