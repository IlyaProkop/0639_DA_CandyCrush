using DG.Tweening;
using System.Collections;
using UnityEngine;

public class UmbrellaFloatAnimation : MonoBehaviour
{
    [SerializeField] private float swayDuration = 2f; // ������������ �������
    [SerializeField] private float swayRange = 1f; // ��������� ������� �� ��� Z
    [SerializeField] private float floatDuration = 3f; // ������������ �������� ����� � �����
    [SerializeField] private float floatRange = 2f; // ��������� �������� ����� � �����

    private Vector3 initialPosition;

    Coroutine coroutine;

    private void Awake()
    {
        initialPosition = transform.localPosition;
    }

    private void OnEnable()
    {
        AnimateSway();
    }
    private void OnDisable()
    {
        StopCoroutine(coroutine);
    }

    private void AnimateSway()
    {
        coroutine = StartCoroutine(delay());
    }
    private IEnumerator delay()
    {
        yield return new WaitForSeconds(Random.Range(0f, 3f));
        transform.DOLocalRotateQuaternion(Quaternion.Euler(0, 0, swayRange), swayDuration)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo)
            .SetLink(gameObject); // �������� � gameObject ��� �������������� ��������� ��� ����������� �������

        AnimateFloat();
    }

    private void AnimateFloat()
    {
        Vector3 targetPosition = initialPosition + new Vector3(-Random.Range(floatRange, floatRange+5), Random.Range(floatRange, floatRange+5), 0);

        transform.DOLocalMove(targetPosition, floatDuration)
            .SetEase(Ease.InOutSine)
            .OnComplete(ReturnToInitialPosition)
            .SetLink(gameObject); // �������� � gameObject ��� �������������� ��������� ��� ����������� �������
    }

    private void ReturnToInitialPosition()
    {
        Vector3 targetPosition = initialPosition;

        transform.DOLocalMove(targetPosition, floatDuration)
            .SetEase(Ease.InOutSine)
            .OnComplete(AnimateFloat); // ����� ����������� �������� ����� �������� ��������
    }
}
