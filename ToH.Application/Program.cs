// See https://aka.ms/new-console-template for more information

using ToH;
using ToH.Data;
using ToH.Log;
using ToH.Screens;

var db = new HeroesContainer();
var log = new ConsoleLog();
var printer = new ConsolePrinter();
var initScreen = new HeroesListScreen(db, log, printer);

var controller = new Controller();
var ui = new Ui(controller, initScreen);
ui.Print();

controller.ListenForInput();