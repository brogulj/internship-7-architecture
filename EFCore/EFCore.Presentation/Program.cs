using EFCore.Presentation.Extensions;
using EFCore.Presentation.Factories;
using System;

namespace EFCore.Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            var mainMenuActions = MainMenuActionFactory.GetMainMenuActions();
            mainMenuActions.PrintActionsAndCall();
        }
    }
}
