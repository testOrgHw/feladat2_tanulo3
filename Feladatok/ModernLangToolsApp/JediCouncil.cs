using System;
using System.Collections.Generic;
using System.Text;

namespace ModernLangToolsApp
{
    public class JediCouncil
    {
        //létrehozok egy Jedi típusú elemektet tartalmazó listát
        List<Jedi> members = new List<Jedi>();
        //event és delegate a változások történésének nyomon követésére
        public event CouncilChangedDelegate CouncilChanged;
        public delegate void CouncilChangedDelegate(string message);

        //hozzáad egy Jedit a listához
        public void Add(Jedi j)
        {
            members.Add(j);
            CouncilChanged?.Invoke("Új taggal bővültünk");
        }
        //eltávolítja az utolsó elemet a listából
        public void Remove()
        {
            members.RemoveAt(members.Count - 1);
            if (CouncilChanged != null) {
                if (members.Count > 0)
                    CouncilChanged("Zavart érzek az erőben");
                else
                    CouncilChanged("A tanács elesett!");
            }
        }

        public delegate bool Predicate(Jedi j);
        
        //ellenőrzi hogy a szám 300 alatt van-e, ha igen akkor igaz értékkel tér vissza
        static bool lesserThan300(Jedi j)
        {
            return j.midichloriancount < 300;
        }
        //visszatér a 300 alatti midichlorian számú jedik listájával
        public List<Jedi> GetBeginners()
        {
            return members.FindAll(lesserThan300);
        }
        
    }
}
