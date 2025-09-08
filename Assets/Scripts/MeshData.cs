using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Данные сетки для отображения
/// </summary>
public class MeshData
{
    public List<Vector3> vertices = new List<Vector3>(); // Список вершин
    public List<int> triangles = new List<int>(); // Список треугольников для передачи в сетку
    public List<Vector2> uv = new List<Vector2>(); // Список u v координат для текстур

    public List<Vector3> colliderVertices = new List<Vector3>(); // Список вершин для коллайдера (физика)
    public List<int> colliderTriangles = new List<int>(); // Список треугольников для коллайдера

    public MeshData waterMesh; // Шейдер для воды
    private bool isMainMesh = true; // Вспомогательный флаг для создания конструктора

    /// <summary>
    /// Массив данных для новой сетки воды
    /// </summary>
    /// <param name="isMainMesh"></param>
    public MeshData(bool isMainMesh)
    {
        if (isMainMesh)
        {
            waterMesh = new MeshData(false);
        }
    }

    /// <summary>
    /// Добавление вершин в список вершин
    /// </summary>
    /// <param name="vertex">Вектор с 3мя вершинами</param>
    /// <param name="vertexGeneratesCollider">Генерация коллайдера</param>
    public void AddVertex(Vector3 vertex, bool vertexGeneratesCollider)
    {
        vertices.Add(vertex);
        if (vertexGeneratesCollider)
        {
            colliderVertices.Add(vertex);
        }

    }


    /// <summary>
    /// Создание квадрата "векторно"
    /// </summary>
    /// <param name="quadGeneratesCollider">Генерация коллайдера</param>
    public void AddQuadTriangles(bool quadGeneratesCollider)
    {
        // 1й треугольник грани
        triangles.Add(vertices.Count - 4); 
        triangles.Add(vertices.Count - 3);
        triangles.Add(vertices.Count - 2);

        // 2й треугольник грани
        triangles.Add(vertices.Count - 4);
        triangles.Add(vertices.Count - 2);
        triangles.Add(vertices.Count - 1);

        if (quadGeneratesCollider)
        {
            colliderTriangles.Add(colliderVertices.Count - 4);
            colliderTriangles.Add(colliderVertices.Count - 3);
            colliderTriangles.Add(colliderVertices.Count - 2);

            colliderTriangles.Add(colliderVertices.Count - 4);
            colliderTriangles.Add(colliderVertices.Count - 2);
            colliderTriangles.Add(colliderVertices.Count - 1);
        }
    }
}
