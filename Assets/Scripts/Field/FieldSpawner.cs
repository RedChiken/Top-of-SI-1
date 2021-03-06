﻿using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

public class FieldSpawner : MonoBehaviour
{
    private const string FieldObjectName = "Field";

    [SerializeField]
    private Cell[] sampleCells;
    [SerializeField]
    private GameObject cellEffect;
    [SerializeField]
    private Vector2Int fieldLength;

    public Field SpawnField()
    {
        var fieldObject = CreateFieldObject();
        var includedCells = new List<List<Cell>>();
        int pointedIndex = 0;

        for (int xPositionInField = 0; xPositionInField < fieldLength.x; ++xPositionInField)
        {
            var rowCells = new List<Cell>();
            for (int yPositionInField = 0; yPositionInField < fieldLength.y; ++yPositionInField)
            {
                var createdCell = Instantiate(sampleCells[pointedIndex], fieldObject.transform);
                
                createdCell.transform.position = CalculateCellPosition(fieldObject.transform.position, xPositionInField, yPositionInField);
                createdCell.gameObject.SetActive(true);

                CreateCellEffect(createdCell);

                rowCells.Add(createdCell);
                pointedIndex = (pointedIndex + 1) % sampleCells.Length;
            }

            includedCells.Add(rowCells);
        }

        fieldObject.SetIncludedCells(includedCells.Select(rowCells => rowCells as IEnumerable<Cell>));

        return fieldObject;
    }

    private Field CreateFieldObject()
    {
        var fieldObject = new GameObject().AddComponent<Field>();
        fieldObject.name = FieldObjectName;
        fieldObject.transform.position = this.transform.position;

        return fieldObject;
    }

    private GameObject CreateCellEffect(Cell createdCell)
    {
        if (cellEffect == null)
        {
            DebugLogger.LogWarning("FieldSpawner::CreateCellAreaParticle => Cell에 생성할 AreaParticle이 없으므로 파티클을 생성하지 않습니다.");
            return null;
        }

        var createdEffect = Instantiate(cellEffect, createdCell.gameObject.transform);

        createdEffect.gameObject.SetActive(false);
        createdEffect.transform.position = createdCell.transform.position;

        createdCell.Effect = createdEffect.gameObject;
        return createdEffect;
    }

    private Vector3 CalculateCellPosition(Vector3 origin, int xPositionInField, int yPositionInField)
    {
        return new Vector3(origin.x + xPositionInField * sampleCells.First().Size.x,
                           origin.y,
                           origin.z + yPositionInField * sampleCells.First().Size.y);
    }
}
