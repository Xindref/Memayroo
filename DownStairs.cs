using UnityEngine;
using System.Collections;

public class DownStairs : MonoBehaviour {

    public Transform warpTarget;

    void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.position = new Vector3(warpTarget.position.x, 2.5f, warpTarget.position.z - 1);
    }
}
