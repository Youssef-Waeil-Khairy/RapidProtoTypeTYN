using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Jeff.Project3.KillHandler 
{
    public class KillHandler : MonoBehaviour
    {
        public AudioSource gunShooting; // AudioSource for the gun shooting 
        public AudioSource bloodSplatter; // AudioSource for the blood splatter 
        public float killDistance = 5f; // Distance which the player can kill
        void Update()
        {
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                // Check for prisoners in range and kill them
                DetectAndKillPrisoner();
            }
        }

        private void DetectAndKillPrisoner()
        {
            // Find all GameObjects tagged as "Prisoner"
            GameObject[] prisoners = GameObject.FindGameObjectsWithTag("Prisoner");

            foreach (GameObject prisoner in prisoners)
            {
                // Calculate the distance between the player and the prisoner
                float distanceToPrisoner = Vector3.Distance(transform.position, prisoner.transform.position);

                // Check if the prisoner is within range
                if (distanceToPrisoner <= killDistance)
                {
                    // Start the kill sequence for this specific prisoner
                    StartCoroutine(KillPrisonerSequence(prisoner));
                    break; // Exit after killing the first detected prisoner
                }
            }
        }

        private IEnumerator KillPrisonerSequence(GameObject prisoner)
        {
            // Play the gun shooting sound
            if (gunShooting != null)
            {
                gunShooting.Play();
                yield return new WaitForSeconds(gunShooting.clip.length); // Wait for sound to finish
            }

            // Play the blood splatter sound
            if (bloodSplatter != null)
            {
                bloodSplatter.Play();
                yield return new WaitForSeconds(bloodSplatter.clip.length); // Wait for sound to finish
            }

            // Destroy the prisoner GameObject
            Destroy(prisoner);

            // Transition to the "WinScene"
            SceneManager.LoadScene("WinScene");
        }
    }
}

