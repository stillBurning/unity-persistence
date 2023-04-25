using Assets.Scripts.Persistance.Exceptions;
using System;
using System.IO;
using System.Runtime.Serialization;
using UnityEngine;

namespace Assets.Scripts.Persistance
{
    public class Repository<Dto> 
        where Dto : class
    {
        private readonly string saveFileName;
        private readonly string saveFilePath;

        public Repository()
        {
            saveFileName = "savefile.json";
            saveFilePath = Path.Combine(Application.persistentDataPath, saveFileName);
        }

        public virtual void Save(Dto dto)
        {
            ThrowIfDtoNotSerializable();
            var json = JsonUtility.ToJson(dto);
            File.WriteAllText(saveFilePath, json);
        }

        public virtual Dto Load()
        {
            ThrowIfDtoNotSerializable();
            try
            {
                var json = File.ReadAllText(saveFilePath);
                return JsonUtility.FromJson<Dto>(json);
            }
            catch (Exception exception)
            {
                throw new SaveNotFoundException("Save file not found", exception);
            }
        }

        private void ThrowIfDtoNotSerializable()
        {
            if (!typeof(Dto).IsSerializable
                && !(typeof(ISerializable).IsAssignableFrom(typeof(Dto))))
                throw new IncompatibleFormatException("A serializable Type is required");
        }
    }
}
