using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollCircle : ScrollRect
{
    // 玩家
    public GameObject player;
    public GameObject effect;

    // 半径
    private float _mRadius = 0f;

    // 距离
    private const float Dis = 0.5f;

    protected override void Start()
    {
        // 获取当前玩家
        player = GameObject.FindWithTag("Player");
        effect = player.GetComponent<PlayerController>().effect;
        if (player==null) Debug.Log("Player error");
        base.Start();

        // 能移动的半径 = 摇杆的宽 * Dis
        _mRadius = content.sizeDelta.x * Dis;
    }

    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);

        // 获取摇杆，根据锚点的位置。
        Vector2 contentPosition = content.anchoredPosition;

        // 判断摇杆的位置 是否大于 半径
        if (contentPosition.magnitude > _mRadius)
        {
            // 设置摇杆最远的位置
            contentPosition = contentPosition.normalized * _mRadius;
            SetContentAnchoredPosition(contentPosition);
        }

        // 最后根据anchoredPosition确定施加的力
        Vector2 v2 = content.anchoredPosition;
        player.GetComponent<Rigidbody>().AddForce(v2);
        effect.GetComponent<EffectControl>().update(v2);
    }
}