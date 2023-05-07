using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{

    void Update(){
        if (transform.position.y < -2f){
            Die();
        }
    }
    [SerializeField] AudioSource deathSound;
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Enemy Body"))
        {
            Die();
        }
        
    }

    void Die(){
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<PlayerMovement>().enabled = false;
        Invoke(nameof(ReloadLevel), 3f);
        deathSound.Play();
    }

    void ReloadLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
