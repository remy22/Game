using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLibrary.Global
{
    public static class Data
    {
        /*
        public static void Save<T>(T data, string fileName)
        {

            Stream stream = null;
            IFormatter formatter = new BinaryFormatter();
            stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, data);
            if (null != stream)
            {
                stream.Close();
            }
        }

        public static T Load<T>()
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            // Insert code to read the stream here.
                            IFormatter formatter = new BinaryFormatter();
                            //Stream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.None);
                            myStream.Flush();
                            T file = (T)formatter.Deserialize(myStream);
                            return file;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
            return default(T);
        }

        /// <summary>
        /// Opens a save file dialogue
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        public static void Save<T>(T data)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            //saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            saveFileDialog1.Title = "Save File";
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    IFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(myStream, data);
                    if (null != myStream)
                    {
                        myStream.Close();
                    }
                    // Code to write the stream goes here.
                    myStream.Close();
                }
            }
        }

        public static T Load<T>(string fileName)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.None);
            stream.Flush();
            T file = (T)formatter.Deserialize(stream);
            return file;
        }
         */

    }
}
