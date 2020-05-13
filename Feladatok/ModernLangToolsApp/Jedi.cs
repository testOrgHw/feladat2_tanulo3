using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace ModernLangToolsApp
{
    [XmlRoot("Jedi")]
    public class Jedi
    {
        //név
        private string Name;
        //midichlorian szám
        private int MidiChlorianCount;

        //konstruktor: átvesz egy nevet és egy számot, majd beállítja őket
        public Jedi(string name,int midi)
        {
            Name = name;
            MidiChlorianCount = midi;
        }
        public Jedi() { }

        [XmlAttribute("Nev")]
        //getter setter metódusok
        public string name {
            get { return Name; }
            set { Name = value; }
        }

        [XmlAttribute("MidiChlorianSzam")]
        //getter setter metódusok
        public int midichloriancount
        {
            get { return MidiChlorianCount; }
            set { 
                if(value<10) 
                    throw new ArgumentException("You are not a true jedi!");
                MidiChlorianCount = value;
            }
        }
        

    }

    
}
