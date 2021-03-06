﻿using UnityEngine;
using System;
using System.Collections;
using Model;

public class Cell : MonoBehaviour, IEventDisposable
{
    public const int Layer = 9;

    public event Action<GameObject> OnMouseClicked = delegate { };

    [SerializeField]
    private Vector2Int size;
    [SerializeField]
    private int layerMaskOnlyForProgrammer;

    private void OnMouseDown()
    {
        OnMouseClicked(gameObject);
    }

    public GameObject Effect
    {
        private get; set;
    }

    public Vector2Int Size
    {
        get
        {
            return size;
        }
    }

    public Vector2Int PositionInField
    {
        get; set;
    }

    public bool HasObjectOnCell()
    {
        int programmerOnlyMask = (1 << layerMaskOnlyForProgrammer);

        var detectedProgrammers =
            Physics.BoxCastAll(center: transform.position,
                               halfExtents: new Vector3(Size.x / 2.0f, 3f, Size.y / 2.0f),
                               direction: Vector3.up,
                               maxDistance: 10f,
                               orientation: Quaternion.identity,
                               layermask: programmerOnlyMask);

        return detectedProgrammers.Length > 0;
    }

    public void SetEffectActiveState(bool newState)
    {
        if (Effect == null)
        {
            DebugLogger.LogWarning("Cell::SetAreaParticleActiveState => AreaParticle 상태를 변경하려 했지만, 설정된 파티클이 없습니다.");
        }
        else
        {
            Effect.gameObject.SetActive(newState);
        }
    }

    public void DisposeRegisteredEvents()
    {
        OnMouseClicked = delegate { };
    }
}
