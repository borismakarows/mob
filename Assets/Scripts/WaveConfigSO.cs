using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] Transform patternPrefab;


    public Transform GetPatternPoint(int index)
    {
        List<Transform> patternPoints = new List<Transform>();
        foreach (Transform child in patternPrefab) { patternPoints.Add(child); }
        return patternPoints[index];
    }

    public int GetPatternPointCount()
    {
        return patternPrefab.childCount;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }


    public GameObject GetEnemyPrefab()
    {
        return enemyPrefab;
    }
}
