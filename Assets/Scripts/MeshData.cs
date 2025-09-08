using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������ ����� ��� �����������
/// </summary>
public class MeshData
{
    public List<Vector3> vertices = new List<Vector3>(); // ������ ������
    public List<int> triangles = new List<int>(); // ������ ������������� ��� �������� � �����
    public List<Vector2> uv = new List<Vector2>(); // ������ u v ��������� ��� �������

    public List<Vector3> colliderVertices = new List<Vector3>(); // ������ ������ ��� ���������� (������)
    public List<int> colliderTriangles = new List<int>(); // ������ ������������� ��� ����������

    public MeshData waterMesh; // ������ ��� ����
    private bool isMainMesh = true; // ��������������� ���� ��� �������� ������������

    /// <summary>
    /// ������ ������ ��� ����� ����� ����
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
    /// ���������� ������ � ������ ������
    /// </summary>
    /// <param name="vertex">������ � 3�� ���������</param>
    /// <param name="vertexGeneratesCollider">��������� ����������</param>
    public void AddVertex(Vector3 vertex, bool vertexGeneratesCollider)
    {
        vertices.Add(vertex);
        if (vertexGeneratesCollider)
        {
            colliderVertices.Add(vertex);
        }

    }


    /// <summary>
    /// �������� �������� "��������"
    /// </summary>
    /// <param name="quadGeneratesCollider">��������� ����������</param>
    public void AddQuadTriangles(bool quadGeneratesCollider)
    {
        // 1� ����������� �����
        triangles.Add(vertices.Count - 4); 
        triangles.Add(vertices.Count - 3);
        triangles.Add(vertices.Count - 2);

        // 2� ����������� �����
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
