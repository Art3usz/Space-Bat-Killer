using System.Collections;
using UnityEngine;

public class HideOnLoadScript : MonoBehaviour
{
    public float hideAfterXSedons = 0.1f;

    // Use this for initialization
    private void Start()
    {
        StartCoroutine(HideAfterXSexonds(hideAfterXSedons));
    }

    private IEnumerator HideAfterXSexonds(float x)
    {
        yield return new WaitForSeconds(x);
        gameObject.SetActive(false);
    }


}
