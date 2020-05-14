using System;
using System.Collections.Generic;
using System.Text;
using CDManager.View;
using CDManager.Data;
using CDManager.Models;

namespace CDManager.Controllers
{
    public class CDController
    {
        CDView Menu = new CDView();
        CDRepository Data = new CDRepository();
        public void Run()
        {
            int userChoice = 0;
            do
            {
                CDView Menu = new CDView();
                userChoice = Menu.GetMenuChoice();
                switch(userChoice)
                {
                    case 1:
                        CreateCD();
                        break;
                    case 2:
                        DisplayCDs();
                        break;
                    case 3:
                        SearchCDs();
                        break;
                    case 4:
                        EditCD();
                        break;
                    case 5:
                        RemoveCD();
                        break;
                    default:
                        break;
                }
            } while (userChoice > 0);

        }
        private void CreateCD()
        {
            CD newCD = Menu.GetNewCDInfo();
            Data.Create(newCD);
            Menu.Successful();
            Data.CDCatalog = Data.GrowArray(Data.CDCatalog, 1);
        }
        private void DisplayCDs()
        {
            Data.ReadAll();
        }
        private void SearchCDs()
        {
            int CDToSearch = Menu.SearchCD();
            CD CDFound = Data.ReadById(CDToSearch);
            Menu.DisplayCD(CDFound);
        }
        private void EditCD()
        {
            int IdOfCD = Menu.SearchCD();
            CD CDToEdit = Data.ReadById(IdOfCD);
            CD UpdatedCD = Menu.EditCDInfo(CDToEdit);
            Data.Update(IdOfCD, UpdatedCD);
        }
        private void RemoveCD()
        {
            if (Menu.ConfirmRemoveCD())
            {
                int CDToRemove = Menu.SearchCD();
                Data.Delete(CDToRemove);
            }
        }
        
    }
}
