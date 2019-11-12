using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField] private GameObject _spawner;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                player.Damage();
            }

            CharacterController characterController = other.GetComponent<CharacterController>();
            if (characterController != null)
            {
                characterController.enabled = false;
            }
            
            other.transform.position = _spawner.transform.position;

            StartCoroutine(CharacterControllerEnableRoutine(characterController));
        }

        IEnumerator CharacterControllerEnableRoutine(CharacterController characterController)
        {
            yield return new WaitForSeconds(0.5f);
            characterController.enabled = true;
        }
    }
}
