using UnityEngine;
using System.Collections;

public class Token : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        print("Do Something");
        gameObject.SetActive(false);
    }
}
