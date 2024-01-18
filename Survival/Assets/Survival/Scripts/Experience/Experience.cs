using System;
using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;

public class Experience : MonoBehaviour
{
    [ShowInInspector]
    public float Value { get; set; }

    private static Hero Hero => GameController.Instance.Hero;

    private void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, 60f * Time.deltaTime);
    }

    private IEnumerator MoveToHero(Action onEnd = null)
    {
        while (Vector3.Distance(transform.position, Hero.transform.position) > 0.2f)
        {
            var direction = Hero.transform.position - transform.position;
            
            transform.position += direction.normalized * (10f * Time.deltaTime);
            yield return null;
        }
        
        onEnd?.Invoke();
    }

    private void HeroCollectExperience()
    {
        Hero.UpdateExperience(Value);
        SimplePool.Despawn(gameObject);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Hero>())
        {
            StartCoroutine(MoveToHero(HeroCollectExperience));
        }
    }
}
