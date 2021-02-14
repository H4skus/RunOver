using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeAndBoom : MonoBehaviour
{
    public ParticleSystem ParticleSystem;
    public GameObject particle;
    bool enable;

    public GameObject killerCuble;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag ==  "Enemy" && !enable)
        {
            particle.SetActive(true);
            ParticleSystem.Play(true);
            StartCoroutine(Boom());
            Cuble();
            enable = true;

        }

    }
    IEnumerator Boom()
    {
        yield return new WaitForSeconds(1.5f);
        particle.SetActive(false);
        ParticleSystem.Play(false);
    }
    void Cuble()
    {
        killerCuble.SetActive(true);
        StartCoroutine(Drop());

    }
    IEnumerator Drop()
    {
        yield return new WaitForSeconds(3);
        killerCuble.SetActive(false);
    }
}
