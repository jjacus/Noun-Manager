using System;
using System.Collections.Generic;
using System.Text;
using CDManager.Models;
using CDManager.View;

namespace CDManager.Data
{
    public class CDRepository
    {
        public CD[] CDCatalog = new CD[2];
        CDView Menu = new CDView();
        public int globalID = 0;
        public CD[] GrowArray(CD[] original, int howManyMoreElements)
        {
            CD[] newArray = new CD[original.Length + howManyMoreElements];

            for (int i = 0; i < original.Length; i++)
            {
                newArray[i] = original[i];
            }

            return newArray;
        }
        public CD Create(CD cd)
        {
            CDCatalog[globalID] = cd;
            cd.Id = globalID++;
            return cd;
        }
        public CD ReadAll()
        {
            for (int i = 0; i < CDCatalog.Length; i++)
            {
                if (CDCatalog[i] == null)
                {
                    break;
                }
                else
                {
                    Menu.DisplayCD(CDCatalog[i]);
                }
            }  
            return null;
        }
        public CD ReadById(int IdToSearch)
        {
            if (CDCatalog[IdToSearch] == null)
            {
                Menu.NoResults();
                return null;
            }
            else
            {
                return CDCatalog[IdToSearch];
            }
        }
        public void Update(int id, CD cd)
        {
            CDCatalog[id] = cd;
            Menu.Successful();
        }
        public void Delete(int id)
        {
            if (CDCatalog[id] == null)
            {
                Menu.NoResults();
            }
            else
            {
                for (int i = id; i < CDCatalog.Length-1; i++)
                {
                    if (CDCatalog[i] == null)
                    {
                        break;
                    }
                    else
                    {
                        CDCatalog[i].Id--;
                        CDCatalog[i] = CDCatalog[i + 1];
                    }
                }
                globalID--;
                Menu.Successful();
            }
        }
    }
}
