using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LootController : MonoBehaviour
{
    [SerializeField] private RarityListSO rarityList;

    private void OnTriggerEnter(Collider other)
    {
        SpawnLoot();
        Destroy(gameObject);
    }

    private void SpawnLoot()
    {
        RaritySO lootRarity = GetRandomRarity();
        if (lootRarity != null)
        {
            Instantiate(lootRarity.prefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }

    private RaritySO GetRandomRarity()
    {
        float rnd = Random.Range(0f, 100f);
        float cumulativeProbability = 0f;

        foreach (var rarity in rarityList.rarities.OrderBy(r => r.probability))
        {
            cumulativeProbability += rarity.probability;
            if (rnd < cumulativeProbability)
            {
                return rarity;
            }
        }

        return rarityList.rarities.Last();
    }
}
