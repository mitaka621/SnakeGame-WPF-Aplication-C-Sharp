using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game.Save_Load
{
    public static class Serializator
    {
        public static void Save(GameModesScore scores)
        {
            using (FileStream writeStream = new FileStream("gameData.bin", FileMode.Create,FileAccess.Write))
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(writeStream, scores);
            }
        }

        public static GameModesScore Load()
        {
            try
            {
                using (FileStream readStream = new FileStream("gameData.bin", FileMode.Open, FileAccess.Read))
                {
                    IFormatter formatter = new BinaryFormatter();
                    return (GameModesScore)formatter.Deserialize(readStream);
                }
            }
            catch (FileNotFoundException)
            {
                return new GameModesScore();
               
            }
           
        }
    }
}
