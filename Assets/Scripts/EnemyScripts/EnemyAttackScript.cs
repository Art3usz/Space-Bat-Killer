using System.Collections;
using UnityEngine;

public class EnemyAttackScript : MonoBehaviour
{
    [Tooltip("Strały na minutę")]
    public float rPM = 1f;
    public bool automaticMode = false;

    private void Start()
    {

    }
    private IEnumerator Attack()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(rPM);
        }
    }
}
