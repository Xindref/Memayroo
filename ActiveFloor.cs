using UnityEngine;
using System.Collections;

public class ActiveFloor : MonoBehaviour {

    public GameObject UpperFloor;
    public GameObject GroundFloor;
    public GameObject Player;
    public GameObject Roof;

	void OnTriggerStay (Collider other) {

        if (other.gameObject.tag == "Inside")
        {
            UpperFloor.SetActive(false);
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.gameObject.tag == "Inside")
        {
            UpperFloor.SetActive(true);
        }
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Downstairs")
        {
            Roof.SetActive(true);
            GetComponent<PlayerMovement>().ChangeLevel();
        }

        if (other.gameObject.tag == "Upstairs")
        {
            Roof.SetActive(false);
            GetComponent<PlayerMovement>().ChangeLevel();
        }
    }
}
