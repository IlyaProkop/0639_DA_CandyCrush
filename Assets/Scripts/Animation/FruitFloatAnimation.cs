using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections.Generic;

public class FruitFloatAnimation : MonoBehaviour
{
    [SerializeField] private float floatRange = 5f;
    [SerializeField] private float floatDuration = 3f;

    private List<RectTransform> fruits = new List<RectTransform>();
    private List<Vector2> initialPositions = new List<Vector2>();

    private void Awake()
    {
        // Get all RectTransform components of child objects
        foreach (RectTransform child in GetComponentsInChildren<RectTransform>())
        {
            if (child != transform) // Skip the parent object itself
            {
                fruits.Add(child);
                initialPositions.Add(child.anchoredPosition);
            }
        }
    }

    private void OnEnable()
    {
        for (int i = 0; i < fruits.Count; i++)
        {
            AnimateFruit(fruits[i], initialPositions[i]);
        }
    }

    private void AnimateFruit(RectTransform fruit, Vector2 initialPosition)
    {
        Vector2 targetPosition = initialPosition + new Vector2(Random.Range(-floatRange, floatRange), Random.Range(-floatRange, floatRange));
        fruit.DOAnchorPos(targetPosition, floatDuration)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);
    }
}
