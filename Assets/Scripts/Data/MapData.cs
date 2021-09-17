using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
namespace FS2.Data
{
    public class MapData
    {
        Dictionary<string, Vector2> mapLocations;

        public MapData()
        {
            //ReadDataFromXML();
        }

        //读取数据从XML
        private void ReadDataFromXML()
        {
            string filePath = "/Resources/Data/XML/MapData.xml";
            XmlDocument xml = new XmlDocument();
            XmlReaderSettings set = new XmlReaderSettings();
            set.IgnoreComments = true;
            //Debug.Log(Application.dataPath);
            xml.Load(XmlReader.Create((Application.dataPath + filePath), set));
            XmlNodeList xmlNodeList = xml.SelectSingleNode("Root").ChildNodes;
            foreach (XmlElement xl1 in xmlNodeList)
            {
                if (xl1.GetAttribute("id") == "1")
                {
                    foreach (XmlElement xl2 in xl1.ChildNodes)
                    {
                        Debug.Log(xl2.GetAttribute("name"));
                    }
                }
            }


        }

        //TODO:需要修改以后
        /// <summary>
        /// 获取地图的基本信息
        /// </summary>
        /// <param name="mapName">传入地图的名字</param>
        public Vector2 GetMapVectorByName(string mapName)
        {
            if(mapLocations.ContainsKey(mapName))
            {
                return mapLocations[mapName];
            }
            else
            {
                Debug.Log("没有该地图的信息！");
                return Vector2.zero;
            }
        }
    }
}
