using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField]
    private UnityEvent _playerDied;

    [SerializeField]
    private UnityEvent _squareCollected;

    [SerializeField]
    private float _scaleChangeDuration;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag(GlobalConstants.ALLY_TAG))
        {
            collider.enabled = false;//�������� ���������, ����� �������� �� ��������� 2 ����.

            collider.transform
        .DOScale(Vector3.zero, _scaleChangeDuration)//������� ����� �� 0
                    .OnComplete(() =>
                    {
                        _squareCollected.Invoke();
                        Destroy(collider.gameObject);
                    });//�� ��������� �������� �������� ������
        }

        if (collider.CompareTag(GlobalConstants.ENEMY_TAG))
        {
            _playerDied.Invoke();
            Destroy(collider.gameObject);
        }
    }
}
