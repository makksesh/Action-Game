using UnityEngine;
using UnityEngine.LightTransport;


/// <summary>
/// Данные о чанках
/// </summary>
public class ChunkData
{
    public BlockType[] blocks; // Массив о типах блоков (вокселей)
    public int chunkSize = 16; // Размер чанка
    public int chunkHeight = 100; // Высота чанка
    public World worldReference; // Ссылка на мир, в котором находится данный чанк
    public Vector3Int worldPosition; // Позиция в мире, где находится этот чанк

    public bool modifiedByThePlayer = false; // Для словаря чанков исходника

    /// <summary>
    /// Конструктор создания чанка
    /// </summary>
    /// <param name="chunkSize">Размер чанка</param>
    /// <param name="chunkHeight">Высота чанка</param>
    /// <param name="world">Ссылка на мир</param>
    /// <param name="worldPosition">Координаты чанка в мировом пространстве</param>
    public ChunkData(int chunkSize, int chunkHeight, World world, Vector3Int worldPosition)
    {
        this.chunkHeight = chunkHeight;
        this.chunkSize = chunkSize;
        this.worldReference = world;
        this.worldPosition = worldPosition;
        blocks = new BlockType[chunkSize * chunkHeight * chunkSize]; // Количество блоков, которое представляет данный чанк
    }
}
