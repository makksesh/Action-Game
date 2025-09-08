using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

// Обязательные параметры, для работы рендера
[RequireComponent(typeof(MeshFilter))] // каркас
[RequireComponent(typeof(MeshRenderer))] // текстуры
[RequireComponent(typeof(MeshCollider))] // коллизии 
public class ChunkRenderer : MonoBehaviour
{
    MeshFilter meshFilter; // Фильтр сетки
    MeshCollider meshCollider; // Коллайдер сетки
    Mesh mesh; // Объект сетки
    public bool showGizmo = false; // для отображения только видимых вокселей

    public ChunkData ChunkData { get; private set; } // ссылка на чанк с данными на воксели

    /// <summary>
    /// Статус: изменил ли игрок данные нашего чанка
    /// </summary>
    public bool ModifiedByThePlayer
    {
        get
        {
            return ChunkData.modifiedByThePlayer;
        }
        set
        {
            ChunkData.modifiedByThePlayer = value;
        }
    }

    /// <summary>
    /// Доступ к сеткам
    /// </summary>
    private void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshCollider = GetComponent<MeshCollider>();
        mesh = meshFilter.mesh;
    }

    /// <summary>
    /// Получение данных о чанке
    /// </summary>
    /// <param name="data"></param>
    public void InitializeChunk(ChunkData data)
    {
        this.ChunkData = data;
    }

    /// <summary>
    /// Рендеринг 
    /// </summary>
    /// <param name="meshData">Данные сетки</param>
    private void RenderMesh(MeshData meshData)
    {
        mesh.Clear();

        mesh.subMeshCount = 2; // Подсетка
        mesh.vertices = meshData.vertices.Concat(meshData.waterMesh.vertices).ToArray(); // Объекдинение водной сетки вместе с землей 

        mesh.SetTriangles(meshData.triangles.ToArray(), 0); // Треугольники для подсетки 1 (subMeshCount) - земля под водой
        mesh.SetTriangles(meshData.waterMesh.triangles.Select(val => val + meshData.vertices.Count).ToArray(), 1); // Добавляем смещение для сетки воды

        mesh.uv = meshData.uv.Concat(meshData.waterMesh.uv).ToArray(); // Объединяем u v координаты 2х сеток
        mesh.RecalculateNormals(); // Пересчитываем нормали для света

        meshCollider.sharedMesh = null;
        Mesh collisionMesh = new Mesh();
        // Коллизии, но не для воды
        collisionMesh.vertices = meshData.colliderVertices.ToArray();
        collisionMesh.triangles = meshData.colliderTriangles.ToArray();
        collisionMesh.RecalculateNormals();

        meshCollider.sharedMesh = collisionMesh;
    }

    /// <summary>
    /// Обновление чанка
    /// </summary>
    public void UpdateChunk()
    {
        RenderMesh(Chunk.GetChunkMeshData(ChunkData));
    }

    public void UpdateChunk(MeshData data)
    {
        RenderMesh(data);
    }

#if UNITY_EDITOR
    //Техническое отображение чанка в редакторе
    private void OnDrawGizmos()
    {
        if (showGizmo)
        {
            if (Application.isPlaying && ChunkData != null)
            {
                if (Selection.activeObject == gameObject)
                    Gizmos.color = new Color(0, 1, 0, 0.4f);
                else
                    Gizmos.color = new Color(1, 0, 1, 0.4f);

                Gizmos.DrawCube(transform.position + new Vector3(ChunkData.chunkSize / 2f, ChunkData.chunkHeight / 2f, ChunkData.chunkSize / 2f), new Vector3(ChunkData.chunkSize, ChunkData.chunkHeight, ChunkData.chunkSize));
            }
        }
    }
#endif
}
