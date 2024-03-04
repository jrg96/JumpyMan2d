using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballEnemyGenerator : MonoBehaviour
{
    [SerializeField]
    private float _timeBetweenLastFireball;

    [SerializeField]
    private float _verticalSpawnOffset;

    [SerializeField]
    private GameObject _fireballPrefab;

    public bool CanCreateFireball { get; set; }

    private void Start()
    {
        // At the beginning of Fireball Generator, generate a fireball
        CanCreateFireball = false;
        CreateFireball();
    }

    private void FixedUpdate()
    {
        if (CanCreateFireball)
        {
            CanCreateFireball = false;
            StartCoroutine(FireballGenerationRoutine());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if object is fireball
        FireballEnemy enemy = collision.GetComponent<FireballEnemy>();

        if (enemy != null)
        {
            CanCreateFireball = true;
            Destroy(collision.gameObject);
        }
    }

    private IEnumerator FireballGenerationRoutine()
    {
        yield return new WaitForSeconds(_timeBetweenLastFireball);
        CreateFireball();
    }

    private void CreateFireball()
    {
        if (_fireballPrefab != null)
        {
            Vector3 position = new Vector3(
                transform.position.x
                , transform.position.y + _verticalSpawnOffset
                , 0);

            Instantiate(_fireballPrefab, position, Quaternion.identity);
        }
        
    }
}
