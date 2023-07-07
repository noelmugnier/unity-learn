using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private bool _canSendDog = true;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (!Input.GetKeyDown(KeyCode.Space))
            return;
        
        if (!_canSendDog)
            return;

        _canSendDog = false;
        Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        
        Invoke(nameof(ResetCanSendDog), 1);
    }

    private void ResetCanSendDog()
    {
        _canSendDog = true;
    }
}
