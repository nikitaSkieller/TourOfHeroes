// See https://aka.ms/new-console-template for more information

using ToH;
using ToH.Data;
using ToH.Log;
using ToH.Screens;

var db = new HeroesContainer();
var printer = new ConsolePrinter();
var initScreen = new HeroesListScreen(db, printer);

var controller = new Controller();
var log = new ConsoleLog();
var ui = new Ui(controller, initScreen, log);
ui.Print();

controller.ListenForInput();