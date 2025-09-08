using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Создание меню для 3D объектов в инспекторе
[CreateAssetMenu(fileName = "Block Data", menuName = "Data/Block Data")]
public class BlockDataSO : ScriptableObject
{
    public float textureSizeX, textureSizeY; // размер текстур (вспомогательные)
    public List<TextureData> textureDataList; // список текстур
}

[Serializable]
public class TextureData
{
    public BlockType blockType; // Тип блока
    public Vector2Int up, down, side; // Вверх, низ, бока блока
    public bool isSolid = true; // 
    public bool generatesCollider = true; // Коллайдер для этого объекта
}