using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameLibrary.Interfaces;

namespace GameLibrary.Managers.YTables
{
    public class YTable : GameObjectList
    {
        public Dictionary<float, YPartition> dictionary = new Dictionary<float, YPartition>();
        private int _partitionHeight;
        private bool _partitioned = false;

        public YTable(int partitionHeight)
        {
            _partitionHeight = partitionHeight;
        }


        public void checkPartition()
        {
            if (!_partitioned)
            {
                partition();
            }
        }

        public void partitionObject(IGameObject iGameObject)
        {
            YPartition t = getPartitionAt(iGameObject.top);
            YPartition b = getPartitionAt(iGameObject.bottom);

            t.Add(iGameObject);
            t.Sort();
            if (t != b)
            {
                b.Add(iGameObject);
                b.Sort();
            }
        }

        private void partition()
        {
            for (int i = 0; i < Count; i++)
            {
                partitionObject(this[i]);
            }
            foreach (KeyValuePair<float, YPartition> entry in dictionary)
            {
                entry.Value.Sort();
            }
            _partitioned = true;
        }

        public YPartition getPartitionAt(float y)
        {
            float index = y - (y % _partitionHeight);
            if (!dictionary.ContainsKey(index))
            {
                YPartition newPartition = new YPartition(index, index + _partitionHeight);
                dictionary.Add(index, newPartition);
            }
            return dictionary[index];
        }

        public void clearDictionary()
        {
            foreach (KeyValuePair<float, YPartition> entry in dictionary)
            {
                entry.Value.Clear();
            }
            dictionary.Clear();
            _partitioned = false;
        }

        public override void checkInternalCollisions()
        {
            checkPartition();

            foreach (KeyValuePair<float, YPartition> entry in dictionary)
            {
                entry.Value.checkInternalCollisions();
            }
        }

        public void checkExternalCollisionsY(YTable list)
        {
            checkPartition();
            list.checkPartition();

            foreach (KeyValuePair<float, YPartition> entry in dictionary)
            {
                if (list.dictionary.ContainsKey(entry.Key))
                {
                    YPartition otherPartition = list.dictionary[entry.Key];
                    entry.Value.checkExternalCollisions(otherPartition);
                }
            }
        }
    }
}
