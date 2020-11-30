using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCard : MonoBehaviour
{
    [SerializeField] private RectTransform _inventoryPanel;

    private Sprite _sprite;

    private void Start ()
    {
        _sprite = GetComponent<SpriteRenderer>().sprite;
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.TryGetComponent<RocketMessage>(out RocketMessage rocketMessage))
        {
            rocketMessage.ShowMessage("blue card collected", _sprite);
            if (_inventoryPanel != null)
                _inventoryPanel.gameObject.SetActive(true);
            _inventoryPanel.gameObject.GetComponent<CanvasGroup>().DOFade(0.7f, 0.5f);
            gameObject.SetActive(false);
        }
    }
}
