using UnityEngine;

public class DontDestroyScript : MonoBehaviour
{

    // Use this for initialization
    private void Start()
    {
        GameObject.DontDestroyOnLoad(this);
    }


}
