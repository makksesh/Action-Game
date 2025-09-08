using UnityEngine;
using UnityEngine.LightTransport;


/// <summary>
/// ������ � ������
/// </summary>
public class ChunkData
{
    public BlockType[] blocks; // ������ � ����� ������ (��������)
    public int chunkSize = 16; // ������ �����
    public int chunkHeight = 100; // ������ �����
    public World worldReference; // ������ �� ���, � ������� ��������� ������ ����
    public Vector3Int worldPosition; // ������� � ����, ��� ��������� ���� ����

    public bool modifiedByThePlayer = false; // ��� ������� ������ ���������

    /// <summary>
    /// ����������� �������� �����
    /// </summary>
    /// <param name="chunkSize">������ �����</param>
    /// <param name="chunkHeight">������ �����</param>
    /// <param name="world">������ �� ���</param>
    /// <param name="worldPosition">���������� ����� � ������� ������������</param>
    public ChunkData(int chunkSize, int chunkHeight, World world, Vector3Int worldPosition)
    {
        this.chunkHeight = chunkHeight;
        this.chunkSize = chunkSize;
        this.worldReference = world;
        this.worldPosition = worldPosition;
        blocks = new BlockType[chunkSize * chunkHeight * chunkSize]; // ���������� ������, ������� ������������ ������ ����
    }
}
