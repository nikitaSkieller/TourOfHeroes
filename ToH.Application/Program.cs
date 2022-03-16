// See https://aka.ms/new-console-template for more information

using ToH;
using ToH.BLL;
using ToH.Data;
using ToH.Log;
using ToH.PL;
using ToH.PL.Screens;

var db = new HeroesContainer();
var printer = new ConsolePrinter();
var log = new ConsoleLog();
var screenFactory = new ScreenFactory(db, printer, log);
var initScreen = screenFactory.CreateScreen(typeof(HeroesListScreen));

var controller = new Controller();
var ui = new Ui(controller, initScreen, log, screenFactory);

controller.ListenForInput();