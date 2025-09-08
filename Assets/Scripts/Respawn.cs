using StarterAssets;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.LightTransport;

public class Respawn
{
    public World world;
    public GameObject player;

    public void Spawn()
    {
        Vector3? firstAirBlockPosition = null;

        Dictionary<Vector3Int, ChunkData> worldData = world.GetChunkData();

        ChunkData data = worldData.Values.First();
        Chunk.LoopThroughTheBlocks(data, (x, y, z) =>
        {
            if (firstAirBlockPosition.HasValue) return; // Уже найден, пропускаем

            if (Chunk.GetBlockFromChunkCoordinates(data, x, y, z) == BlockType.Air)
            {
                firstAirBlockPosition = new Vector3(x, y, z);
                player.transform.position = firstAirBlockPosition.Value;
            }
        });
    }

}
