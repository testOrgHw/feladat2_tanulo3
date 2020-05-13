using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;

namespace ModernLangToolsApp
{
    class Program : XmlSerializer
    {
        //az érkezett üzenetet kiírja az outputra
        static void MessageReceived(string message) 
        { 
            Console.WriteLine(message); 
        }
        //átvesz egy tanácsot és feltölti azt Jedi elemekkel
        public static void Fill(JediCouncil jc)
        {
            jc.Add(new Jedi("Anakin", 20000));
            jc.Add(new Jedi("Yoda", 19000));
            jc.Add(new Jedi("Obi-Wan", 15000));
            jc.Add(new Jedi("BB-8", 100));
            jc.Add(new Jedi("Rey", 0));
        }
        
        [Description("Feladat2")]
        //klónozó függvény, kiír egy Jedit egy fájlba, majd visszaolvassa azt
        public static Jedi clone(Jedi j)
        {

            XmlSerializer serializer = new XmlSerializer(typeof(Jedi));
            FileStream stream = new FileStream("jedi.txt", FileMode.Create);
            serializer.Serialize(stream, j);
            stream.Close();


            XmlSerializer ser = new XmlSerializer(typeof(Jedi));
            FileStream fs = new FileStream("jedi.txt", FileMode.Open);
            Jedi clone = (Jedi)ser.Deserialize(fs);
            fs.Close();
            return clone;
        }
        [Description("Feladat3")]
        //készít egy tanácsot, feltölti azt jedikkel 
        //ha változás történik, akkor azt kiírja a standard outputra
        public static void MakeCouncil()
        {
            JediCouncil council = new JediCouncil();
            council.CouncilChanged += MessageReceived;
            council.Add(new Jedi("Anakin", 20000));
            council.Add(new Jedi("Yoda", 19000));
            council.Add(new Jedi("Obi-Wan", 15000));

            council.Remove();
            council.Remove();
            council.Remove();
        }
        [Description("Feladat4")]
        //kiirja a "tanonc"(<300) Jediket a standard outputra
        public static void ListApprentice(JediCouncil jc)
        {
            List<Jedi> jedis = jc.GetBeginners();
            foreach(Jedi j in jedis)
            {
                Console.WriteLine("\n"+ j.name + " we do not grant you the rank of master");
            }
        }
        static void Main(string[] args)
        {
            //2. feladat
            Jedi j = new Jedi("Obi-Wan", 15000);
            Jedi j2 = clone(j);

            //3. feladat
            MakeCouncil();

            //4. feladat
            JediCouncil jc = new JediCouncil();
            Fill(jc);
            ListApprentice(jc);

            Console.ReadKey();
            
            
        }
    }
}
