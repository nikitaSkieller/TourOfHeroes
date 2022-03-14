// See https://aka.ms/new-console-template for more information

using ToH;
using ToH.Log;
using ToH.Screens;

var controller = new Controller();
var db = new HeroesContainer();
var log = new ConsoleLog();
var initScreen = new HeroesListScreen(db, log);
var ui = new Ui(controller, initScreen);
ui.Print();

controller.ListenForInput();